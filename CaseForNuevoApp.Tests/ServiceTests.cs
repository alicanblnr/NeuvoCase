
using CaseForNuevo.Bussiness.Services;
using System;
using System.Globalization;
using Xunit;

namespace CaseForNuevoApp.Tests
{
    public class ServiceTests
    {
        [Theory, InlineData(new object[] { "1", "false" ,"true"})]
        public void OrderedList_Returns_Not_Null(string banknoteBuying,string result, string expected)
        {
            var service = new TCMBService();
            var response = service.SortedBySelectedField(new CaseForNuevo.Bussiness.SearchArgs.CurrencyRateSearchArgs { BanknoteBuying = banknoteBuying });
            if (response != null)
                result = "true";

            var actual = result;
            Assert.Equal(expected, actual);
        }
    }
}
