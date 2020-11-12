using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DomainLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI_MVC.Core.Models;

namespace UI_MVC.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        // The constructor specifies that anyone wanting to use the class must provide an instance of an IProductService interface.
        public HomeController(IProductService productService)
        {
            if (productService == null)
                throw new ArgumentNullException("productService");
            // The injected DepenDency can be stored for later and safely used by other members of the HomeController class.
            _productService = productService;
        }

        public ViewResult Index()
        {
            //-----Hard-Code-------------------------------------------------------------------------------
            // Creates a view model with a hard-coded list of discounted products
            //var vm = new FeaturedProductsViewModel(new[] {
            //    new ProductViewModel("Chocolate", 34.95m),
            //    new ProductViewModel("Asparagus", 39.80m)
            //});
            //---------------------------------------------------------------------------------------------

            IEnumerable<FeaturedDiscountedProduct> products = _productService.GetFeaturedDiscountedProducts();
            var vm = new FeaturedDiscountedProductsVM(from product in products
                                                   select new FeaturedDiscountedProductVM(product));

            // Wraps the view model in an MVC ViewResult object using MVC’s helper method, View
            return View(vm);
        }
    }
}
