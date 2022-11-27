using AppBancos2Northwind.DbService.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancos2Northwind.DbService
{
    public class DbCalls
    {

        private string connectionString = @"Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=douglas@0100";

        public ObservableCollection<Product> GetProducts(Order order)
        {

            string customerID = order.CustomerID;

            string GetProductsQuery = "SELECT odd.ProductID, prd.ProductName, prd.UnitPrice" +
                " FROM dbo.Orders ord JOIN dbo.[Order Details] odd" +
                " ON ord.OrderID = odd.OrderID JOIN dbo.Products prd" +
                " ON odd.ProductID = prd.ProductID WHERE ord.CustomerID = '" + customerID + "'" +
                " ORDER BY odd.ProductID";

            var products = new ObservableCollection<Product>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var product = new Product();
                                    product.ProductId = reader.GetInt32(0);
                                    product.ProductName = reader.GetString(1);
                                    product.ProductUnitPrice = reader.GetDecimal(2);
                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }



        public ObservableCollection<Order> GetOrders()
        {
            string GetOrdersQuery = "SELECT DISTINCT ord.CustomerID, ord.ShipName, ord.ShipCountry" +
                " FROM dbo.Orders ord JOIN dbo.[Order Details] odd" +
                " ON ord.OrderID = odd.OrderID JOIN dbo.Products prd" +
                " ON odd.ProductID = prd.ProductID ORDER BY ord.CustomerID";

            var Orders = new ObservableCollection<Order>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetOrdersQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var order = new Order();
                                    order.CustomerID = reader.GetString(0);
                                    order.OrderShipName = reader.GetString(1);
                                    order.OrderShipCountry = reader.GetString(2);
                                    order.Products = GetProducts(order);
                                    Orders.Add(order);
                                }
                            }
                        }
                    }
                }
                return Orders;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }


    }
}
