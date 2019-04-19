using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;
using System;
using System.ComponentModel.DataAnnotations;

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

		[DataType(DataType.DateTime)]
		[Display(Name = "This is the selected date")]
		[Required(ErrorMessage = "Please select a date")]
		public DateTime SomeAwesomeDate { get; set; }

		public IActionResult OnGet(WizzardData wizzardData)
		{
			mapper.Map(wizzardData, this);

			return Page();
		}

		public IActionResult OnPostBackToIndex()
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