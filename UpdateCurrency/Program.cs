using DomainLogic;
using Microsoft.Extensions.Configuration;
using SqlDataAccessLayer;
using System;

namespace UpdateCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            // The 4 responsabilities of any Composition Root *********************************************

            // Responsability 1: Load configuration values
            string connectionString = LoadConnectionString();


            // Responsability 2:Building the object graph
            var provider =
                new SqlExchangeRateProvider(
                    new CommerceContext(connectionString));

            decimal exchangeRate = -1;

            if (args == null || args.Length != 2 || !decimal.TryParse(args[1], out exchangeRate))
            {
                Console.WriteLine("Usage: UpdateCurrency <USD | GBP> <rate>");
            }

            var currencyCode = args[0];

            Currency currency = currencyCode switch
            {
                "USD" => Currency.Dollar,
                "EUR" => Currency.Euro,
                "GBP" => Currency.Pound,
                _ => throw new Exception("user choice of the currencey to update the exchange rate ")
            };

            // Responsability 3: Invoke the desired functionality (to do that, we must have Object graph & other things like args !!)
            provider.UpdateExchangeRate(currency, exchangeRate);

            // Responsability 4: Release the object graph

            //*********************************************************************************************

        }

        private static string LoadConnectionString()
        {
            var configuration = new ConfigurationBuilder()
            // Microsoft.Extensions.Configuration.FileExtensions
            .SetBasePath(@"C:\Users\Adil\Source\Repos\DIPPP_source-code\Adil_Official\Adil_WorkingMinimalMvcProject_Add_Currency\UpdateCurrency")
            // Microsoft.Extensions.Configuration.Json
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            return
                configuration.GetConnectionString("CommerceConnectionString");
        }

    }
}
