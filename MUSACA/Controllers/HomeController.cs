namespace MUSACA.Controllers
{
   
    using Data;
    using Models;
    using ViewModels.Home;
    using ViewModels.Orders;

    using System.Linq;
    using SIS.HTTP.Responses;
    public class HomeController : BaseController
    {
        public HomeController(MusacaDb musacaDb) : base(musacaDb)
        {
        }

        public IHttpResponse Index()
        {
            
            if (this.User.IsLoggedIn)
            {

                var orders = this.Db.Orders
                    .Where(status => status.Status.Equals(Status.Active))
                    .Select(order => new OrderActiveViewModel
                    {
                        ProductName=order.Product.Name,
                        Quantity=order.Quantity,
                        Total=order.Total
                    })
                    .ToList();

                var model = new OrdersActiveViewModel
                {
                    Orders=orders
                };

                return this.View("Home/IndexLoggedIn", model);
            }

            return this.View();
        }
    }
}
