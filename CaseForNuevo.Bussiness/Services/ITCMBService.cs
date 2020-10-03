using CaseForNuevo.Bussiness.SearchArgs;
using CaseForNuevo.Data.Models;
using System;


namespace CaseForNuevo.Bussiness.Services
{
    public interface ITCMBService : IDisposable
    {
        ResponseModel GetAll();
        CurrencyModel Get(CurrencyRateSearchArgs args);
        ResponseModel SortedBySelectedField(CurrencyRateSearchArgs args);
        void ExportCSV(ResponseModel responseModel);
    }
}
