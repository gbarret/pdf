using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class LabelSpouse
  {
    // Page 1. Label Spouse ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SSN_Part_1 { get; set; }
    public string SSN_Part_2 { get; set; }
    public string SSN_Part_3 { get; set; }
    public string PresidentialElectionCampaign { get; set; }

    public void RetrieveData()
    {
      // 20170704 Need to get data from DataBase per year ...
      this.FirstName = "Mary";
      this.LastName = "Smith";
      this.SSN_Part_1 = "321";  // SSN.Substring(0, 3) ...
      this.SSN_Part_2 = "78";   // SSN.Substring(3, 2) ...
      this.SSN_Part_3 = "0005"; // SSN.Substring(5, 4) ...
      this.PresidentialElectionCampaign = "Yes";  // Yes/No/Off, Default Off ...
    }

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_006(0)", this.FirstName);
      this.keys.Add("f1_007(0)", this.LastName);
      this.keys.Add("f1_008(0)", this.SSN_Part_1);
      this.keys.Add("f1_009(0)", this.SSN_Part_2);
      this.keys.Add("f1_010(0)", this.SSN_Part_3);
      this.keys.Add("c1_002(0)", this.PresidentialElectionCampaign);
    }
  }
}