using BTLONKY5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTLONKY5.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly QLDBcontext _context;

	
		public HomeController(QLDBcontext context, ILogger<HomeController> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var viewModel = new IndexViewModel
			{
				Categories = await _context.Categories.ToListAsync(),
				Foods = await _context.Foods.ToListAsync(),
			};

			return View(viewModel);
		}

		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
