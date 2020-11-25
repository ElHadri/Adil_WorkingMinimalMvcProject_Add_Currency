
using DomainLogic;

using Microsoft.Extensions.Configuration;

using SqlDataAccessLayer;

using System;
using System.Globalization;
using System.Linq;
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

        static string LoadConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            // Microsoft.Extensions.Configuration.FileExtensions
            .SetBasePath(@"C:\Users\Adil\Source\Repos\DIPPP_source-code\Adil_Official\Adil_WorkingMinimalMvcProject_Add_Currency\UI_Console")
            // Microsoft.Extensions.Configuration.Json
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            return
                configuration.GetConnectionString("CommerceConnectionString");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // The 4 responsabilities of any Composition Root *********************************************

            // Responsability 1: Load configuration values
            string connectionString = LoadConnectionString();
            var commerceContext = new CommerceContext(connectionString);

            // Responsability 2: Build the object graph
            IProductService productService = new ProductService(
                 new SqlProductRepository(commerceContext),
                 new ConsoleUserContextAdapter(false, Currency.Dollar),
                 new CurrencyConverter(new SqlExchangeRateProvider(commerceContext)));

            // Responsability 3: Invoke the desired functionality
            var products = productService.GetFeaturedDiscountedProducts();

            // Responsability 4: Release the object graph

            //*********************************************************************************************


            // mon View
            Console.WriteLine("******************************");
            Console.WriteLine("Featured products:");
            Console.WriteLine("******************************");

            foreach (var product in products)
            {
                // To Do : CultureInfo
                Console.WriteLine(string.Format(new CultureInfo("fr-BE"), "{0} ({1:C})", product.Name, product.UnitPrice.Amount));
            }
        }
    }
}
