using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Commons;
using MUSACA.Models;
using MUSACA.ViewModels.Home;
using MUSACA.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MUSACA.Controllers {
    public class ProductsController : BaseController {
        public ProductsController(MusacaDb musacaDb) : base(musacaDb) {

        }

        [Authorize("Admin")]
        public IHttpResponse Create() {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateProductInputModel model) {
            var product = new Product {
                Name = model.Name,
                Price = model.Price,
                Picture = model.Picture,
                Barcode = model.Barcode
            };

            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return this.Redirect("/Products/Details?id=" + product.Id);
        }
        [Authorize]
        public IHttpResponse Details(int id) {
            var viewModel = this.Db.Products
                .Select(x => new ProductDetailsViewModel {
                    Picture = x.Picture,
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Barcode = x.Barcode

                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null) {
                return this.BadRequestError(Constants.InvalidUserId);
            }

            return this.View(viewModel);
        }

        [Authorize]

        public IHttpResponse ProductsAll() {
            var products = this.Db.Products
                .Select(p => new ProductViewModel {

                    Name = p.Name,
                    Price = p.Price,
                    Barcode = p.Barcode,

                    Picture = p.Picture,
                    Id = p.Id
                })
                .ToList();


            var model = new AllProductsViewModel { Products = products };

            return View(model);
        }
        [Authorize("Admin")]
        public IHttpResponse Edit(int id) {
            var viewModel = this.Db.Products
                .Select(x => new UpdateDeleteProductInputModel() {
                    Barcode = x.Barcode,
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Picture = x.Picture,
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null) {
                return this.BadRequestError(Constants.InvalidUserId);
            }


            return this.View(viewModel);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(UpdateDeleteProductInputModel model) {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == model.Id);
            if (product == null) {
                return this.BadRequestError(String.Format(Constants.NotFoundedProduct, model.Id));
            }

            product.Barcode = model.Barcode;
            product.Picture = model.Picture;
            product.Name = model.Name;
            product.Price = model.Price;

            this.Db.SaveChanges();

            return this.Redirect("/Products/ProductsAll");
        }

        [Authorize("Admin")]
        public IHttpResponse Delete(int id) {
            var viewModel = this.Db.Products
                .Select(x => new UpdateDeleteProductInputModel() {
                    Id = x.Id,
                    Name = x.Name,
                    Barcode = x.Barcode,
                    Picture = x.Picture,
                    Price = x.Price
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null) {
                return this.BadRequestError(Constants.InvalidUserId);
            }

            return this.View(viewModel);

        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(int id, string name) {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) {
                return this.Redirect("/");
            }

            this.Db.Remove(product);
            this.Db.SaveChanges();

            return this.Redirect("/Products/ProductsAll");
        }

    }
}
