using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using RapidPay.Domain.Repositories;
using RapidPay.Domain.Validations;
using RapidPay.Infrastructure.Services;

namespace RapidPay.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IFeeHistoryRepository _feeHistoryRepository;
        private readonly IFeeExchangeService _feeExchangeService;
        private readonly IMapper _mapper;

        public PaymentService(
            ICardRepository cardRepository, 
            IPaymentRepository paymentRepository,
            IFeeHistoryRepository feeHistoryRepository,
            IFeeExchangeService feeExchangeService,
            IMapper mapper)
        {
            _cardRepository = cardRepository;
            _paymentRepository = paymentRepository;
            _feeHistoryRepository = feeHistoryRepository;
            _feeExchangeService = feeExchangeService;
            _mapper = mapper;
        }

        public async Task<ValidationMessage> CreatePayment(PaymentForCreationDTO paymentForCreationDTO)
        {
            var card = await _cardRepository.GetCard(paymentForCreationDTO.CardId);

            if (card == null)
            {
                return new ValidationMessage(false, "Card not found.");
            }

            var payment = _mapper.Map<Payment>(paymentForCreationDTO);

            var currentFeeExchange = _feeExchangeService.GetFeeExchange();
            var lastFeeHistory = await _feeHistoryRepository.GetLastFeeHistory();

            payment.Fee = lastFeeHistory != null ? decimal.Round(lastFeeHistory.Rate * currentFeeExchange, 2) : currentFeeExchange;

            if (lastFeeHistory == null || lastFeeHistory.Exchange != currentFeeExchange)
            {
                UpdateFeeHistory(payment.Fee, currentFeeExchange);
            }

            if (payment.Amount + payment.Fee > card.BalanceAmount)
            {
                return new ValidationMessage(false, "Card does not have enough funds.");
            }

            card.BalanceAmount -= payment.Amount + payment.Fee;

            await _paymentRepository.CreatePayment(payment);
            await _cardRepository.UpdateCard(card);

            return new ValidationMessage(true, string.Empty);
        }

        private void UpdateFeeHistory(decimal rate, decimal exchange)
        {
            _feeHistoryRepository.CreateFeeHistory(new FeeHistory
            {
                Rate = rate,
                Exchange = exchange
            });
        }
    }
}