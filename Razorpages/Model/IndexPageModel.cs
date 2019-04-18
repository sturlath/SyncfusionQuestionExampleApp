﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Razorpages.Model
{
	public class IndexPageModel
	{
		[DataType(DataType.Date)]
		[Display(Name = "This is a date")]
		[Required(ErrorMessage = "Please select a date")]
		public DateTime SomeAwesomeDate { get; set; }
	}
}