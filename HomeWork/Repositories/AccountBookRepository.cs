using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeWork.Models;
using HomeWork.ViewModels;

namespace HomeWork.Repositories
{
	public class AccountBookRepository
	{
		HomeworkModel __hwm ;

		public AccountBookRepository(HomeworkModel hwm)
		{
			if(hwm !=null )
			{
				this.__hwm = hwm;
			}			
		}


		public IEnumerable<Models.AccountBook> selectAllRow()
		{
			var list = __hwm.AccountBooks.Select(x => x).OrderByDescending(x=>x.Dateee);

			return list;
		}

		public bool WriteData(AccountBook input)
		{
			try
			{
				input.Id =  Guid.NewGuid();
				__hwm.AccountBooks.Add(input);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}