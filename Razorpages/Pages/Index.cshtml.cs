using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;
using System;

namespace Razorpages.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public IndexPageModel IndexPageModel { get; set; }

		public IActionResult OnGet()
		{
			// Would need this if I'm using value in the picker because it then shows DateTime.MinValue but we like today
			//if(IndexPageModel.SomeAwesomeDate == DateTime.MinValue)
			//{
			//	IndexPageModel.SomeAwesomeDate = DateTime.UtcNow;
			//}

			if (!ModelState.IsValid) return Page();

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();

			string value = Request.Form["hiddenDateTimeValueInputName"];
			IndexPageModel.SomeAwesomeDate = Convert.ToDateTime(value);

			return RedirectToPage("./SecondPage", IndexPageModel);
		}
	}
}

