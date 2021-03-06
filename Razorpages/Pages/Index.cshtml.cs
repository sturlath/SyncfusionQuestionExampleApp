﻿using AutoMapper;
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
		private readonly IMapper mapper;

		public IndexModel(IMapper mapper)
		{
			this.mapper = mapper;
		}

		[DataType(DataType.DateTime)]
		[Display(Name = "This is a date")]
		[Required(ErrorMessage = "Please select a date")]
		public DateTime? SomeAwesomeDate { get; set; }

		[Display(Name = "Validation test")]
		[Required(ErrorMessage = "Needs to be filled out")]
		public string ValidationTest { get; set; }

		public IActionResult OnGet(WizzardData wizzardData)
		{
			if (!ModelState.IsValid) return Page();

			mapper.Map(wizzardData, this);

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();

			string value = Request.Form["hiddenDateTimeValueInputName"];
			SomeAwesomeDate = Convert.ToDateTime(value);

			var wizzardData = new WizzardData();
			mapper.Map(this, wizzardData);

			return RedirectToPage("./SecondPage", wizzardData);
		}
	}
}

