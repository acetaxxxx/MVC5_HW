using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.ViewModels;
using HomeWork.Repositories;
using HomeWork.Models;
using System.Collections;
using System.Globalization;

namespace HomeWork.Service
{
	class AccountBookService
	{
		HomeworkModel __hmw;
		AccountBookRepository accountBookRes;

		public AccountBookService()
		{

			__hmw = new HomeworkModel();
			accountBookRes = new AccountBookRepository(__hmw);
		}

		public IEnumerable<BoughtItem> GetAllData()
		{
			IEnumerable<AccountBook> originData = accountBookRes.selectAllRow();

			var result = originData.Select(x => new BoughtItem()
			{
				ItemCategory = x.Categoryyy == 0 ? "支出" : "收入" ,
				ItemDate = x.Dateee.ToString("yyyy-MM-dd") ,
				Price = x.Amounttt
			}).ToList();

			return result;
		}

		public bool WtrieData(BoughtItem obj)
		{
			AccountBook result;


			int amounttt;
			DateTime dateee;

			if (int.TryParse(obj.Price.ToString() , out amounttt) &&
				 String.IsNullOrWhiteSpace(obj.ItemCategory) == false &&
				DateTime.TryParseExact(obj.ItemDate , "yyyy-MM-dd" , DateTimeFormatInfo.CurrentInfo , DateTimeStyles.None , out dateee) &&
				String.IsNullOrWhiteSpace(obj.Remark) == false)
			{
				result = new AccountBook()
				{
					Categoryyy = obj.ItemCategory == "支出" ? 0 : 1 ,
					Amounttt = amounttt ,
					Dateee = dateee ,
					Remarkkk = obj.Remark

				};
				if (accountBookRes.WriteData(result))
				{
					__hmw.SaveChanges();
					return true;
				}
			}


			return false;
		}

	}
}