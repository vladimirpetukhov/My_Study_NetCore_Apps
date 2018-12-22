namespace MUSACA.Controllers {
    using MUSACA.Data;
    using SIS.HTTP.Responses;
    using Commons;
    using System;
    using System.Linq;
    using SIS.WebServer.Results;
    using MUSACA.ViewModels.Receipts;
    using SIS.MvcFramework;
    using MUSACA.ViewModels.Products;
    using MUSACA.ViewModels.Users;
    using MUSACA.ViewModels.Orders;
    using System.Collections.Generic;

    public class ReceiptsController : BaseController {
        public ReceiptsController(MusacaDb musacaDb) : base(musacaDb) {
        }
        [Authorize("Admin")]
        public IHttpResponse All() {

            var receipts = this.Db.Receipts.ToList();
            var model = new AllReceiptsViewModel();
            var model1 = new AllReceiptViewModel();
            foreach (var item in receipts) {

                model1 = new AllReceiptViewModel {
                    Id = item.Id,
                    Cashier = item.Cashier.Username,
                    IssuedOn = item.IssuedOn,
                    Total = item.Orders.Select(t => t.Total).Sum()
                };
                model.Receipts.Add(model1);
            }
            


            return View(model);
        }

        [Authorize]
        public IHttpResponse Details(int id) {
            var receipt = this.Db.Receipts
                .Where(r => r.Id == id)
                .Select(x => new ReceiptOrdersViewModel {
                    Cashier = x.Cashier.Username,
                    Id = x.Id,
                    IssuedOn = x.IssuedOn,
                    Orders = x.Orders.Select(y => new ReceiptViewModel {
                        ProductName = y.Product.Name,
                        Quantity = y.Quantity,
                        Total = y.Total
                    }
                    ).ToList()
                }).SingleOrDefault();


            if (receipt == null) {
                return BadRequestError(String.Format(Constants.ReceiptInvalid, id));
            }

            return View(receipt);
        }
    }
}
