using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Razorpages.Pages
{
	[BindProperties(SupportsGet = true)]
	public class IndexModel : PageModel
	{
		private readonly IMapper _mapper;

		public IndexModel(IMapper mapper)
		{
			_mapper = mapper;
		}

		[DataType(DataType.DateTime)]
		[Display(Name = "This is a date")]
		//[Required(ErrorMessage = "Please select a date")]
		public DateTime SomeAwesomeDate { get; set; }

		public IActionResult OnGet(WizzardData wizzardData)
		{
			// How do I update the date picker with the value the second time?

			_mapper.Map(wizzardData, this);

			// Would need this if I'm using value in the picker because it then shows DateTime.MinValue but we like today
			//if(SomeAwesomeDate == DateTime.MinValue)
			//{
			//	SomeAwesomeDate = DateTime.UtcNow;
			//}

			if (!ModelState.IsValid) return Page();

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();

			string value = Request.Form["hiddenDateTimeValueInputName"];
			SomeAwesomeDate = Convert.ToDateTime(value);

			var wizzardData = new WizzardData();
			_mapper.Map(this, wizzardData);

			return RedirectToPage("./SecondPage", wizzardData);
		}
	}
}

