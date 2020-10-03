using CaseForNuevo.Data.Models;


namespace CaseForNuevo.ExternalServices.TCMB
{
    public interface IBankService
    {
        ResponseModel GetCurrencies();
    }
}
