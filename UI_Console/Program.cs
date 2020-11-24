
using DomainLogic;

using SqlDataAccessLayer;

using System;
using System.Globalization;
using System.Text;

//using UI_MVC.Core.Controllers;
//using UI_MVC.Core.Models;

namespace UI_Console
{
    class Program
    {
        //ici j'utilise "UI_MVC.Core" project**********************************************************************************************************************
        //static void Main(string[] args)
        //{
        //    Console.OutputEncoding = Encoding.Unicode;

        //    string connectionString = args[0];

        //    // comme le travail de 'CustomControllerActivator'
        //    HomeController controller = CreateController(connectionString);

        //    var result = controller.Index();
        //    var vm = (FeaturedDiscountedProductsVM)result.Model;

        //    // mon View
        //    Console.WriteLine("Featured products:");
        //    foreach (var product in vm.Products)
        //    {
        //        Console.WriteLine(product.SummaryText);
        //    }
        //}

        //// Acts as the application’s COMPOSITION ROOT
        //private static HomeController CreateController(string connectionString)
        //{
        //    return /*Builds the application's object graph*/
        //        new HomeController(new ProductService(new SqlProductRepository(new CommerceContext(connectionString)),
        //               new ConsoleUserContextAdapter()));
        //}
        //**********************************************************************************************************************

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; 

            string connectionString = args[0];

            // Composition Root
            var products = new ProductService(
                 new SqlProductRepository(new CommerceContext(connectionString)),
                 new ConsoleUserContextAdapter(true, Currency.Euro),
                 new CurrencyConverter())
                 .GetFeaturedDiscountedProducts();

            // mon View
            Console.WriteLine("Featured products:");

            foreach (var product in products)
            {
                Console.WriteLine(string.Format(new CultureInfo("fr-BE"), "{0} ({1:C})", product.Name, product.UnitPrice.Amount));
            }
        }
    }
}
