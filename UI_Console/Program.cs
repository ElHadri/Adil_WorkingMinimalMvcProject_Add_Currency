using System;
using System.Text;
using DomainLogic;
using SqlDataAccessLayer;
using UI_MVC.Core.Controllers;
using UI_MVC.Core.Models;

namespace UI_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string connectionString = args[0];

            // comme le travail de 'CustomControllerActivator'
            HomeController controller = CreateController(connectionString);

            var result = controller.Index();
            var vm = (FeaturedProductsVM)result.Model;

            // mon View
            Console.WriteLine("Featured products:");
            foreach (var product in vm.Products)
            {
                Console.WriteLine(product.SummaryText);
            }
        }

        // Acts as the application’s COMPOSITION ROOT
        private static HomeController CreateController(string connectionString)
        {
            return /*Builds the application's object graph*/
                new HomeController(new ProductService(new SqlProductRepository(new CommerceContext(connectionString)),
                       new ConsoleUserContextAdapter()));
        }
    }
}
