
using CaseForNuevo.Bussiness.SearchArgs;
using CaseForNuevo.Bussiness.Services;
using CaseForNuevo.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseForNuevo.App
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                       .AddTransient<ITCMBService, TCMBService>()
                       .BuildServiceProvider();
            ITCMBService tcmbService = serviceProvider.GetService<ITCMBService>();


            var exportFlag = false;
            Console.WriteLine(@"Do you want export after execute? Y\N" );
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {
                exportFlag = true;
            }


            Console.WriteLine(@"GetAll Method ? Press 1");
            Console.WriteLine(@"Get Method? Press 2");
            Console.WriteLine(@"SortedBySelectedField Method? Press 3");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1)
            {
                var response = tcmbService.GetAll();
                if (exportFlag)
                    tcmbService.ExportCSV(response);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            if (keyInfo.Key == ConsoleKey.D2)
            {
                var response = tcmbService.Get(new CurrencyRateSearchArgs { Name = "ABD DOLARI" });
                List<CurrencyModel> list = new List<CurrencyModel>();
                list.Add(response);
                if (exportFlag)
                    tcmbService.ExportCSV(new ResponseModel {Currency = list });
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            if (keyInfo.Key == ConsoleKey.D3)
            {
                var response = tcmbService.SortedBySelectedField(new CurrencyRateSearchArgs { BanknoteBuying = "1" });
                if (exportFlag)
                    tcmbService.ExportCSV(response);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }

            Console.ReadLine();

        }

    }
}
