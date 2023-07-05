﻿using System;
using Fiorello.Entities;
using Fiorello.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fiorello.Controllers
{
	public class AccountController:Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager,
									SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;

        }

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(AccountRegisterVM model)
		{
			if (!ModelState.IsValid) return View();

			var user = new User
			{
				UserName = model.UserName,
				Email=model.Email,
				Country=model.Country,
				Fullname=model.Fullname,
				PhoneNumber=model.PhoneNumber
			};

			var result = _userManager.CreateAsync(user, model.Password).Result;
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
                    ModelState.AddModelError(string.Empty, error.Description);
					return View();
                }
			}

			return RedirectToAction(nameof(Login));

		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(AccountLoginVM model)
		{
			if (!ModelState.IsValid) return View();

			var user = _userManager.FindByNameAsync(model.UserName).Result;
			if (user is null)
			{
				ModelState.AddModelError(string.Empty,"Username or password is incorrect");
				return View();
			}

			var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
			if (!result.Succeeded)
			{
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }
			return RedirectToAction(nameof(Index), "home");
		}

		//[HttpGet]
		//public IActionResult Logout()
		//{
		//	_signInManager.SignOutAsync();
		//	return RedirectToAction(nameof(Login));
		//}
	}
}

