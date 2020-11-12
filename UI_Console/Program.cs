using System;
using System.Globalization;
using System.Linq;
using System.Text;

using DomainLogic;

using SqlDataAccessLayer;

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

            Console.WriteLine("Are you a preferred customer ?  [True or False]");
            string response = Console.ReadLine();
            bool isPreferredCustomer = bool.Parse(response);


            // Composition Root
            var products = new ProductService(
                 new SqlProductRepository(new CommerceContext(connectionString)),
                 new ConsoleUserContextAdapter(isPreferredCustomer))
                 .GetFeaturedDiscountedProducts();

            // mon View
            Console.WriteLine("Featured products:");
            CultureInfo PriceCulture = new CultureInfo("fr-BE");

            foreach (var product in products)
            {
                Console.WriteLine(string.Format(PriceCulture, "{0} ({1:C})", product.Name, product.UnitPrice));
            }
        }
    }
}
