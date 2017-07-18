using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class PaidPreparer
  {
    // Page 1. Deduction-Exemption Worksheet ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public string PreparerSelfEmployed { get; set; }

    public void RetrieveData()
    {
      // 20170704 Need to get data from DataBase per year ...
      this.PreparerSelfEmployed = "Off";  // Yes/No/Off, Default Off ...
    }

    public void UpdatePdfDictionary()
    {
      this.keys.Add("c1_009(0)", this.PreparerSelfEmployed);
    }
  }
}