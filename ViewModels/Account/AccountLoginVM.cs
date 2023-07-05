using System;
using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModels.Account
{
	public class AccountLoginVM
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

