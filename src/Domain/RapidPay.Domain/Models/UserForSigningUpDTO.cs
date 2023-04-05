﻿using System.ComponentModel.DataAnnotations;

namespace RapidPay.Domain.Models
{
    public class UserForSigningUpDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}