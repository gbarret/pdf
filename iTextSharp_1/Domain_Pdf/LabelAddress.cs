using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class LabelAddress
  {
    // Page 1. Label Address ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public string Address { get; set; }
    public string Apartment { get; set; }
    public string AddressCityStateZip { get; set; }

    public void RetrieveData()
    {
      // 20170704 Need to get data from DataBase per year ...
      this.Address = "200 W 123 St";
      this.Apartment = "9G";
      this.AddressCityStateZip = "New York, NY 10032";  // SSN.Substring(0, 3) ...
    }

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_011(0)", this.Address);
      this.keys.Add("f1_012(0)", this.Apartment);
      this.keys.Add("f1_013(0)", this.AddressCityStateZip);
    }
  }
}