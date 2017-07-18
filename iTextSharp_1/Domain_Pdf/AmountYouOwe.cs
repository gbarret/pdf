using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class AmountYouOwe
  {
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public int AmountOwe { get; set; }

    public void RetrieveData()
    {
      this.AmountOwe = 10000;
    } // End of RetrieveData() ***

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_066(0)", AmountOwe.ToString());
    } // End of updatePdfDictionary() *** 
  }
}