using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HomeWork.Validation
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter , AllowMultiple = false)]
	public sealed class DateRange : ValidationAttribute
	{
		public DateTime _endDate { get; private set; }

		public DateRange()
		{
			this._endDate = DateTime.Now;
		}
		public DateRange(DateTime endDate)
		{
			this._endDate = endDate;
		}

		public override string FormatErrorMessage(string name)
		{

			return $"{name} 請輸入日期小於{_endDate.ToString("yyyy-MM-dd")} 的時間";

		}

		public override bool IsValid(object value)
		{
			if(value==null)
			{
				return true;
			}

			DateTime test=DateTime.Now;

			if(value.GetType()==typeof(string)  )
			{
				if (DateTime.TryParseExact(value as string , "yyyy-MM-dd" , DateTimeFormatInfo.CurrentInfo , DateTimeStyles.None , out test)==false)
				{ return false; }
			}
			if (value.GetType() == typeof(DateTime))
			{
				test =(DateTime) value;
			}
			
			if(_endDate > test)
			{
				return true;
			}

			return false;
		}
		
	}
}