using AppBancos2Northwind.DbService;
using AppBancos2Northwind.DbService.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace AppBancos2Northwind
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public static DbCalls DbCalls = new DbCalls();

        public MainPage()
        {
            this.InitializeComponent();
            products = new ObservableCollection<Product>();
        }

        private ObservableCollection<Order> orders = DbCalls.GetOrders();
        public ObservableCollection<Order> Orders
        {
            get
            {
                return this.orders;
            }

            set
            {
                this.orders = value;
            }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }

        public void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Order selectedOrder = (Order)e.ClickedItem;
            Products = selectedOrder.Products;
        }
    }
}
