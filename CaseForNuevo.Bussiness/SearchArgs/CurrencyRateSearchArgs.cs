using System;
using System.Collections.Generic;
using System.Text;

namespace CaseForNuevo.Bussiness.SearchArgs
{
    public class CurrencyRateSearchArgs
    {
        public string Name { get; set; }
        public string CurrencyName { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
    }
}
