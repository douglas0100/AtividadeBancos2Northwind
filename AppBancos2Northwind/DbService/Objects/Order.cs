using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancos2Northwind.DbService.Objects
{
    public class Order : OnPropertyChanged
    {
        public static int sequence = 1;

        public int id;
        public string CustomerID { get; set; }
        public string OrderShipName { get; set; }
        public string OrderShipCountry { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public Order()
        {
            id = sequence++;
        }

        public override string ToString()
        {
            return string.Format(CustomerID + " / " + OrderShipName + " / " + OrderShipCountry);
        }

    }
}
