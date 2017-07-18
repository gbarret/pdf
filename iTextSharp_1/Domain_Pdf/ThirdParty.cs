using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class ThirdParty
  {
    // Page 1. Deduction-Exemption Worksheet ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public string ThirdPartyDesignee { get; set; }

    public void RetrieveData()
    {
      // 20170704 Need to get data from DataBase per year ...
      this.ThirdPartyDesignee = "No";  // Yes/No/Off, Default No ...
    }

    public void UpdatePdfDictionary()
    {
      this.keys.Add("c1_008(0)", this.ThirdPartyDesignee);
    }
  }
}