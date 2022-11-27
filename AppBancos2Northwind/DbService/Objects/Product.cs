using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancos2Northwind.DbService.Objects
{
    public class Product : OnPropertyChanged
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductUnitPrice { get; set; }
    }
}
