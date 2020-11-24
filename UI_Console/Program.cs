
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

            // Loads configuration values
            string connectionString = LoadConnectionString();
            var commerceContext = new CommerceContext(connectionString);

            // Begin: Update currency ------------------------------------------------------------------------
            Console.WriteLine("Do you want to update the exchange rates ? [y or n]");
            var choice = Console.ReadLine();
            if (choice == "y")
            {
                Console.WriteLine("Enter the currency code (For example: USD)");
                var currencyCode = Console.ReadLine();
                Console.WriteLine("Enter the exchange rate from the primary currency (EUR) to this currency (For example: 1.09)");
                var exchangeRate = Console.ReadLine();
                Currency currency = currencyCode switch
                {
                    "USD" => Currency.Dollar,
                    "EUR" => Currency.Euro,
                    "MAD" => Currency.Pound,
                    _ => throw new Exception("user choice of the currencey to update the exchange rate ")
                };

                var sqlExchangeRateProvider = new SqlExchangeRateProvider(commerceContext);
                sqlExchangeRateProvider.UpdateExchangeRate(currency, Convert.ToDecimal(exchangeRate));

                var exchangeRateModified = commerceContext.ExchangeRates.Single(r => r.CurrencyCode == currency.Code);
                Console.WriteLine($"Update succeeded :  { exchangeRateModified.CurrencyCode} : { exchangeRateModified.Rate }");
            }
            // End: Update currency ------------------------------------------------------------------------


            // Composition Root
            var products = new ProductService(
                 new SqlProductRepository(commerceContext),
                 new ConsoleUserContextAdapter(false, Currency.Dollar),
                 new CurrencyConverter(new SqlExchangeRateProvider(commerceContext)))
                 .GetFeaturedDiscountedProducts();

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
