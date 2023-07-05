using System;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class PagesController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}
	}
}

