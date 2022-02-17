﻿using MUSACA.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace MUSACA.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public HttpResponse Cashout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User.Id;
            var activeOrdersIds = this.ordersService.GetAllActiveOrdersIds(userId);

            foreach (var id in activeOrdersIds)
            {
                this.ordersService.CompleteOrder(id);
            }

            return this.Redirect("/Users/Profile");
        }
    }
}
