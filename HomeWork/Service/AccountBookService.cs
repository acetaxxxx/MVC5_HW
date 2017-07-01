using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.ViewModels;
using HomeWork.Repositories;
using HomeWork.Models;

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

		public BoughtListViewModel GetAllData()
		{
			IEnumerable<AccountBook> originData =  accountBookRes.selectAllRow();
			BoughtListViewModel result = new BoughtListViewModel();
			result.List = originData.Select(x => new BoughtItem()
			{
				ItemCategory = x.Categoryyy.ToString(),
				ItemDate = x.Dateee.ToString("yyyy-MM-dd"),
				Price = x.Amounttt
			}).ToList();

			return result;
		}



	}
}