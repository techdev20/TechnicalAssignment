using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data;
    using Models;

    public class OrderService
    {
        public List<Order> GetOrdersForCompany(int CompanyId)
        {
            // Set Result
            List<Order> result;

            // Set OrderProduct
            List<OrderProduct> orderprod;

            // Get Orders
            result = GetOrders(CompanyId);

            // Get Products
            orderprod = GetProducts(CompanyId);

            // Set Order Product
            foreach (var order in result)
            {
                foreach (var orderproduct in orderprod)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            // Return Result
            return result;
        }

        private List<Order> GetOrders(int CompanyId)
        {
            var database = new Database();

            // Set Result
            List<Order> result = new List<Order>();

            // Get the orders
            var sql1 =
                "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

            using (var reader = database.ExecuteReader(sql1))
            {
                while (reader.Read())
                {
                    var record = (IDataRecord)reader;

                    result.Add(new Order()
                    {
                        CompanyName = record.GetString(0),
                        Description = record.GetString(1),
                        OrderId = record.GetInt32(2),
                        OrderProducts = new List<OrderProduct>()
                    });

                }
                // Close reader
                reader.Close();
            }
            // Return Result
            return result;
        }

        private List<OrderProduct> GetProducts(int CompanyId)
        {
           var database = new Database();
            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var result = new List<OrderProduct>();
            using (var reader = database.ExecuteReader(sql2))
            {
                while (reader.Read())
                {
                    var record = (IDataRecord)reader;

                    result.Add(new OrderProduct()
                    {
                        OrderId = record.GetInt32(1),
                        ProductId = record.GetInt32(2),
                        Price = record.GetDecimal(0),
                        Quantity = record.GetInt32(3),
                        Product = new Product()
                        {
                            Name = record.GetString(4),
                            Price = record.GetDecimal(5)
                        }
                    });
                }
                // Close Reader
                reader.Close();
            }

            // Return Result
            return result;
        }
    }
}