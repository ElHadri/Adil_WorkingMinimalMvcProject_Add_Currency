using CurrencyConverterLibrary;

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
            Console.WriteLine("مرحبا بك");

            string connectionString = args[0];

            Console.WriteLine("Are you a preferred customer ?  [True or False]");
            string response1 = Console.ReadLine();
            bool isPreferredCustomer = bool.Parse(response1);

            Console.WriteLine("What's your favorite currency ?  [EUR, USD, or MAD]");
            string response2 = Console.ReadLine();
            Currency preferredCurrency = response2 switch
            {
                "USD" => Currency.USD,
                "EUR" => Currency.EUR,
                "MAD" => Currency.MAD,
                _ => throw new Exception(response2)
            };

            // Composition Root
            var products = new ProductService(
                 new SqlProductRepository(new CommerceContext(connectionString)),
                 new ConsoleUserContextAdapter(isPreferredCustomer, preferredCurrency),
                 new CurrencyConverterTrial())
                 .GetFeaturedDiscountedProducts();

            // mon View
            Console.WriteLine("Featured products:");

            CultureInfo Culture = preferredCurrency switch
            {
                Currency.EUR => new CultureInfo("fr-BE"),
                Currency.USD => new CultureInfo("en-US"),
                Currency.MAD => new CultureInfo("ar-MA"),
                _ => new CultureInfo("fr-BE")
            };

            foreach (var product in products)
            {
                Console.WriteLine(string.Format(Culture, "{0} ({1:C})", product.Name, product.UnitPrice.Amount));
            }
        }
    }
}
