using CaseForNuevo.Data.Models;
using CaseForNuevo.ExternalServices.Helper;
using System.Xml;

namespace CaseForNuevo.ExternalServices.TCMB
{
    public class BankService : IBankService
    {
        private const string Url = "http://www.tcmb.gov.tr/kurlar/today.xml";
        public ResponseModel GetCurrencies()
        {
            try
            {
                XmlTextReader rdr = new XmlTextReader(Url);
                XmlDocument myxml = new XmlDocument();
                myxml.Load(rdr);
                var result = BankHelper.Deserialize<ResponseModel>(myxml.OuterXml);

                return result;
            }
            catch
            {
                throw;
            }
        }


    }
}
