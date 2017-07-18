using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class LabelTaxpayer
  {
    // Page 1. Label Taxpayer ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SSN_Part_1 { get; set; }
    public string SSN_Part_2 { get; set; }
    public string SSN_Part_3 { get; set; }
    public string PresidentialElectionCampaign { get; set; }

    public void RetrieveData() {
      // 20170704 Need to get data from DataBase per year ...
      this.FirstName = "Pepito";
      this.LastName = "Smith";
      this.SSN_Part_1 = "123";  // SSN.Substring(0, 3) ...
      this.SSN_Part_2 = "12";   // SSN.Substring(3, 2) ...
      this.SSN_Part_3 = "0001"; // SSN.Substring(5, 4) ...
      this.PresidentialElectionCampaign = "Off";  // Yes/No/Off, Default Off ...
    }

    public void UpdatePdfDictionary() {
      this.keys.Add("f1_001(0)", this.FirstName);
      this.keys.Add("f1_002(0)", this.LastName);
      this.keys.Add("f1_003(0)", this.SSN_Part_1);
      this.keys.Add("f1_004(0)", this.SSN_Part_2);
      this.keys.Add("f1_005(0)", this.SSN_Part_3);
      this.keys.Add("c1_001(0)", this.PresidentialElectionCampaign);
    }
  }
}