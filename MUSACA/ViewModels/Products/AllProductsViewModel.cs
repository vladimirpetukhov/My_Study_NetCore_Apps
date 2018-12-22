using MUSACA.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
