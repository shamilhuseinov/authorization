using System;
using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModels.Account
{
	public class AccountRegisterVM
	{
		[Required]
		[MaxLength(50)]
		public string Fullname { get; set; }

		[EmailAddress]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]

        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

