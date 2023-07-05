using System;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class ShopController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}
	}
}

