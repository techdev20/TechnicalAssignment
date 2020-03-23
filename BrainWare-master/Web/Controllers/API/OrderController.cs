using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Models;
    using Web.Filters;

    public class OrderController : ApiController
    {
        [HttpGet]
        [CustomAuth(true)]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            var data = new OrderService();

            // Set Result
            List<Order> result = data.GetOrdersForCompany(id).ToList();

            // Check for empty
            if (result == null)
            {
                var message = string.Format("Order with id = {0} not found", id);

                // Return HttpError
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            else
            {
                //Return Result
                return result;
            }
        }
    }
}
