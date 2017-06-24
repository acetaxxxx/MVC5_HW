using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork.ViewModels;

namespace HomeWork.Controllers
{
    public class HomeController : Controller
    {
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
            BoughtListViewModel BoutListView = ListCreator(200);
            BoutListView.List= BoutListView.List.OrderBy(a => a.ItemDate).ToList();

            return View("BoughtList", BoutListView);
        }
        private BoughtListViewModel ListCreator(int maxNnmber)
        {
            Random rnd = new Random();
            string[] itemCategory = { "支出", "收入" };

            BoughtListViewModel result = new BoughtListViewModel();
            DateTime start = new DateTime(2016, 1, 1);
            for (int i = 0; i < maxNnmber; i++)
            {
                int no = rnd.Next();
                BoughtItem tmp = new BoughtItem()
                {
                    ItemCategory = itemCategory[no % 2],
                    ItemDate = start.AddDays(no%1000).ToString("yyyy-MM-dd"),
                    Price = no
                };
                result.Add(tmp);
            }
            return result;
        }

    }
}