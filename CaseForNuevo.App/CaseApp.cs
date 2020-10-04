using CaseForNuevo.Bussiness.SearchArgs;
using CaseForNuevo.Bussiness.Services;
using CaseForNuevo.Data.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseForNuevo.App
{

    public class CaseApp
    {
        private  readonly ILogger _logger;
        private readonly ITCMBService _service ;

        public CaseApp(ITCMBService service,ILogger logger)
        {
            _logger = logger;
            _service = service;
        }
        public void Run()
        {
            try
            {
                var exportFlag = false;
                Console.WriteLine(@"Do you want export after execute? Y\N");
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
                    var response = _service.GetAll();
                    if (exportFlag)
                        _service.ExportCSV(response);
                    _logger.LogInformation(JsonConvert.SerializeObject(response));
                    //Console.WriteLine(JsonConvert.SerializeObject(response));
                }
                if (keyInfo.Key == ConsoleKey.D2)
                {
                    var response = _service.Get(new CurrencyRateSearchArgs { Name = "ABD DOLARI" });
                    List<CurrencyModel> list = new List<CurrencyModel>();
                    list.Add(response);
                    if (exportFlag)
                        _service.ExportCSV(new ResponseModel { Currency = list });
                    _logger.LogInformation(JsonConvert.SerializeObject(response));
                }
                if (keyInfo.Key == ConsoleKey.D3)
                {
                    var response = _service.SortedBySelectedField(new CurrencyRateSearchArgs { BanknoteBuying = "1" });
                    if (exportFlag)
                        _service.ExportCSV(response);
                    _logger.LogInformation(JsonConvert.SerializeObject(response));
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
