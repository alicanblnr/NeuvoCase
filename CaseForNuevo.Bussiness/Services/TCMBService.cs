using CaseForNuevo.Bussiness.SearchArgs;
using CaseForNuevo.Data.Models;
using CaseForNuevo.ExternalServices.TCMB;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CaseForNuevo.Bussiness.Services
{
    public class TCMBService : ITCMBService
    {
        private readonly IBankService _bankService;
        private readonly ILogger _logger;
        public TCMBService(ILogger logger)
        {
            _bankService = new BankService();
            _logger = logger;
        }

        public void Dispose()
        { }

        public void ExportCSV(ResponseModel responseModel)
        {
            using (var sw = new StreamWriter(@"test.csv", false, new UTF8Encoding(true)))
            using (var cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<CurrencyModel>();
                cw.NextRecord();
                foreach (var curr in responseModel.Currency)
                {
                    cw.WriteRecord(curr);
                    cw.NextRecord();
                }
            }
        }


        public CurrencyModel Get(CurrencyRateSearchArgs args)
        {
            var response = _bankService.GetCurrencies();
            var allCurrenciesList = response.Currency;
            IEnumerable<CurrencyModel> result = new List<CurrencyModel>();
            if (args != null)
            {
                if (args.Name != null && !string.IsNullOrEmpty(args.Name))
                {
                    result = allCurrenciesList.Where(x => x.Isim == args.Name);
                }
                if (args.CurrencyName != null && !string.IsNullOrEmpty(args.CurrencyName))
                {
                    result = allCurrenciesList.Where(x => x.CurrencyName == args.CurrencyName);
                }
                if (args.BanknoteSelling != null && !string.IsNullOrEmpty(args.BanknoteSelling))
                {
                    result = allCurrenciesList.Where(x => x.BanknoteSelling == args.BanknoteSelling);
                }
                if (args.BanknoteBuying != null && !string.IsNullOrEmpty(args.BanknoteBuying))
                {
                    result = allCurrenciesList.Where(x => x.BanknoteBuying == args.BanknoteBuying);
                }

                return result.FirstOrDefault();
            }

            return result.FirstOrDefault();
        }

        public ResponseModel GetAll()
        {
            return _bankService.GetCurrencies();
        }

        public ResponseModel SortedBySelectedField(CurrencyRateSearchArgs args)
        {
            try
            {
                var response = _bankService.GetCurrencies();
                var allCurrenciesList = response.Currency;

                if (args != null)
                {
                    if (args.Name != null && !string.IsNullOrEmpty(args.Name))
                    {
                        response.Currency = allCurrenciesList.OrderBy(x => x.Isim).ToList();
                    }
                    if (args.CurrencyName != null && !string.IsNullOrEmpty(args.CurrencyName))
                    {
                        response.Currency = allCurrenciesList.OrderBy(x => x.CurrencyName).ToList();
                    }
                    if (args.BanknoteSelling != null && !string.IsNullOrEmpty(args.BanknoteSelling))
                    {
                        response.Currency = allCurrenciesList.OrderBy(x => x.BanknoteSelling).ToList();
                    }
                    if (args.BanknoteBuying != null && !string.IsNullOrEmpty(args.BanknoteBuying))
                    {
                        response.Currency = allCurrenciesList.OrderBy(x => x.BanknoteBuying).ToList();
                    }

                    return response;
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


    }
}
