
using CaseForNuevo.Bussiness.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using Xunit;

namespace CaseForNuevoApp.Tests
{
    public class ServiceTests
    {
        //Need DI here.....
        ILogger _logger;
        ITCMBService _TCMBService;
        [Theory, InlineData(new object[] { "1", "false" ,"true"})]
        public void OrderedList_Returns_Not_Null(string banknoteBuying,string result, string expected)
        {
            _TCMBService = new TCMBService(_logger);
            var response = _TCMBService.SortedBySelectedField(new CaseForNuevo.Bussiness.SearchArgs.CurrencyRateSearchArgs { BanknoteBuying = banknoteBuying });
            if (response != null)
                result = "true";

            var actual = result;
            Assert.Equal(expected, actual);
        }
    }
}
