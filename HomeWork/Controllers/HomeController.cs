using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork.ViewModels;
using HomeWork.Models;
using HomeWork.Service;
namespace HomeWork.Controllers
{
	public class HomeController : Controller
	{
		AccountBookService ABS = new AccountBookService();

		public ActionResult Index()
		{

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		
		public ActionResult BoughtList()
		{
			BoughtListViewModel BoutListView;

			if (TempData["ErrorPage"] !=null)
			{
				BoutListView = (BoughtListViewModel) TempData["ErrorPage"];
				ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
			}
			else
			{
				BoutListView = new BoughtListViewModel();
				BoutListView.Result = ABS.GetAllData();
			}
			

			return View("BoughtList" , BoutListView);
		}

		
	

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult WriteData(BoughtListViewModel input)
		{
			BoughtListViewModel BoutListView = new BoughtListViewModel();

			
			if (ModelState.IsValid)
			{
				var flag = ABS.WtrieData(input.InputData);
				if (flag != true)
				{
					BoutListView.InputData.Remark = "出錯啦!!!!";
				}

				BoutListView.Result = ABS.GetAllData();
				BoutListView.InputData = new BoughtItem();
				
				return PartialView("BoughtListGridPartialView" , BoutListView);
			}
			TempData["ErrorPage"] = input;
			TempData["ModelState"] = ModelState;
			return JavaScript($"window.location = '{Url.Action("BoughtList")}'");
		}
		//private BoughtListViewModel ListCreator(int maxNnmber)
		//{
		//    Random rnd = new Random();
		//    string[] itemCategory = { "支出", "收入" };

		//    BoughtListViewModel result = new BoughtListViewModel();
		//    DateTime start = new DateTime(2016, 1, 1);
		//    for (int i = 0; i < maxNnmber; i++)
		//    {
		//        int no = rnd.Next();
		//        BoughtItem tmp = new BoughtItem()
		//        {
		//            ItemCategory = itemCategory[no % 2],
		//            ItemDate = start.AddDays(no%1000).ToString("yyyy-MM-dd"),
		//            Price = no
		//        };
		//        result.Add(tmp);
		//    }
		//    return result;
		//}

	}
}