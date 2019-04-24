using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;
using System;

namespace Razorpages.Pages
{
	[BindProperties(SupportsGet = true)]
	public class SecondPageModel : PageModel
	{
		private readonly IMapper mapper;

		public SecondPageModel(IMapper mapper)
		{
			this.mapper = mapper;
		}

		[HiddenInput]
		public DateTime? SomeAwesomeDate { get; set; }

		public IActionResult OnGet(WizzardData wizzardData)
		{
			mapper.Map(wizzardData, this);

			return Page();
		}

		public IActionResult OnPost()
		{
			var withHiddenIputWeCantDoThis = Request.Form["SomeAwesomeDate"].ToString();

			var wizzard = new WizzardData();
			mapper.Map(this, wizzard);

			return RedirectToPage("./ThirdPage", wizzard);
		}

		public IActionResult OnPostBackToPreviousPage()
		{
			if (!ModelState.IsValid) return Page();

			string value = Request.Form["SomeAwesomeDate"];
			SomeAwesomeDate = Convert.ToDateTime(value);

			var wizzardData = new WizzardData();
			mapper.Map(this, wizzardData);

			return RedirectToPage("./Index", wizzardData);
		}
	}
}