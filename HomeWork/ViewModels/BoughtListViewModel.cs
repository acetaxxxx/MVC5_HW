using HomeWork.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork.ViewModels
{
	public class BoughtListViewModel
	{
		public IEnumerable<BoughtItem> Result { get; set; }

		public BoughtItem InputData { get; set; }

		
		public BoughtListViewModel()
		{
			Result = new List<BoughtItem>();
			InputData = new BoughtItem();
		}
	}

	public class BoughtItem
	{
		
		[Required]
		[Range(0 , 1)]
		public string ItemCategory { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:yyyy-MM-dd}")]
		[DateRange]
		public string ItemDate { get; set; }

		[Required]
		[Range(0,int.MaxValue)]
		public int Price { get; set; }

		[Required]
		[MaxLength(100), MinLength(1)]
		[DataType(DataType.MultilineText)]
		public string Remark { get; set; }
		
		
	}
}

