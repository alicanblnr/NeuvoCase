using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CaseForNuevo.Data.Models
{
	[XmlRoot(ElementName = "Tarih_Date")]
	public class ResponseModel
	{
		[XmlElement(ElementName = "Currency")]
		public List<CurrencyModel> Currency { get; set; }
		[XmlAttribute(AttributeName = "Tarih")]
		public string DateFormatTR { get; set; }
		[XmlAttribute(AttributeName = "Date")]
		public string DateFormatEN { get; set; }
		[XmlAttribute(AttributeName = "Bulten_No")]
		public string Bulletin_No { get; set; }
	}
}
