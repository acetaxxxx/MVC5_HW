using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork.ViewModels
{
    public class BoughtListViewModel
    {
        public List<BoughtItem> List { get; set; }

        public BoughtListViewModel()
        {
            List = new List<BoughtItem>();
        }
        public void Add(BoughtItem it)
        {
            this.List.Add(it);
        }

    }

    public class BoughtItem
    {        
        public string ItemCategory { get; set; }
        public string ItemDate { get; set; }
        public int Price { get; set; }
    }
}
    
