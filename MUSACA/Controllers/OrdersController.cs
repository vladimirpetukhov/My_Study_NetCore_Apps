using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Models;
using MUSACA.ViewModels.Orders;
using MUSACA.ViewModels.Receipts;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MUSACA.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(MusacaDb musacaDb) : base(musacaDb)
        {
        }
        [Authorize]
        [HttpPost]
        public IHttpResponse Order(OrderProductViewModel viewModel)
        {

            var username = this.User.Username;
            var user = this.Db.Users
                .Where(u => u.Username == username)
                .SingleOrDefault();

            var barcode = viewModel.Barcode;
            var product = this.Db.Products
                .Where(b => b.Barcode == barcode)
                .SingleOrDefault();
            if (product == null)
            {
                return this.BadRequestError("Invalid product barcode.");
            }
            var quantity = viewModel.Quantity;

            var order = new Order
            {
                Product = product,
                Cashier = user,
                Total = product.Price * quantity,
                Quantity = quantity,
                Status = Status.Active
            };
            this.Db.Orders.Add(order);
            this.Db.SaveChanges();
            return Redirect("/");
        }
        [Authorize]
        public IHttpResponse Cashout()
        {
            var cashier = this.Db.Users
                .Where(u => u.Username == this.User.Username)
                .SingleOrDefault();

            var completed = this.Db.Orders
                .Where(status => status.Status.Equals(Status.Active))
                .ToList();

            completed.ForEach(order =>
            {
                order.Status = Status.Completed;
            });

            var receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                Orders = completed,
                Cashier = cashier
            };

            this.Db.Receipts.Add(receipt);
            this.Db.SaveChanges();
            if (this.User.Role == "User")
            {
                return Redirect("/Receipts/Details?id=" + receipt.Id);
            }

            return Redirect("/Receipts/All");
        }
    }
}
