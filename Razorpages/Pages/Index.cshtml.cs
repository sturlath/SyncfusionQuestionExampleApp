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

