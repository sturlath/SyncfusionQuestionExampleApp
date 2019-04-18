using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razorpages.Model;

namespace Razorpages.Pages
{
	public class SecondPageModel : PageModel
    {
		[BindProperty(SupportsGet = true)]
		public IndexPageModel IndexPageModel { get; set; }

		public IActionResult OnGet()
		{
			return Page();
		}

		public IActionResult OnPostBackToIndex()
		{
			return RedirectToPage("./Index", IndexPageModel);
		}
	}
}