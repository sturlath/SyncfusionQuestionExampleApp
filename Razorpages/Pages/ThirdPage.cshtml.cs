using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;
using System;

namespace Razorpages.Pages
{
	[BindProperties(SupportsGet = true)]
	public class ThirdPageModel : PageModel
	{
		private readonly IMapper mapper;

		public ThirdPageModel(IMapper mapper)
		{
			this.mapper = mapper;
		}

		public IActionResult OnGet(WizzardData wizzardData)
		{
			mapper.Map(wizzardData, this);

			return Page();
		}

		public DateTime? SomeAwesomeDate { get; set; }

		public IActionResult OnPostBackToPreviousPage()
		{
			if (!ModelState.IsValid) return Page();

			string value = Request.Form["SomeAwesomeDate"];
			SomeAwesomeDate = Convert.ToDateTime(value);

			var wizzardData = new WizzardData();
			mapper.Map(this, wizzardData);

			return RedirectToPage("./SecondPage", wizzardData);
		}
	}
}