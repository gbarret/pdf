using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class RefundInfo
  {
    // Form 1040ez, Page 1, Refund ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public int Refund { get; set; }
    public string Form8888 { get; set; }
    public string RoutingNumber { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }

    public void RetrieveData()
    {
      this.Refund = 10000;
      this.Form8888 = "Off"; // Yes/No/Off, Default Off (2007)...
      this.RoutingNumber = "23456789";
      this.AccountType = "checking";  // 20170704 checking/savings ...
      this.AccountNumber = "345123456";
    } // End of RetrieveData() ***

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_038(0)", Refund.ToString());
      this.keys.Add("c1_005(0)", this.Form8888);
      this.keys.Add("f1_040(0)", RoutingNumber.PadLeft(9,'0')); // 20170704 In case this has 0s at the begining ...
      this.keys.Add("c1_006(0)", AccountType);
      this.keys.Add("f1_049(0)", AccountNumber.PadLeft(17));
    } // End of updatePdfDictionary() *** 
  }

}