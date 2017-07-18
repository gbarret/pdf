using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class Income
  {
    // Form 1040ez, Page 1, Income ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public int WagesSalariesTips { get; set; }
    public int TaxableInterest { get; set; }
    public int UnemploymentAlaskaDiv { get; set; }
    public int AdjustedGrossIncome { get; set; }
    public string Claimed { get; set; }
    public string SpouseClaimed { get; set; }
    public int Deduction { get; set; }
    public int TaxableIncome { get; set; }

    public void RetrieveData()
    {
      this.WagesSalariesTips = 10000;
      this.TaxableInterest = 200;
      this.UnemploymentAlaskaDiv = 3000;
      this.AdjustedGrossIncome = 40;
      this.Claimed = "Yes";  // Yes/No/Off ...
      this.SpouseClaimed = "Yes"; // Yes/No/Off ...
      this.Deduction = 3400;
      this.TaxableIncome = 100000;
    } // End of RetrieveData() ***

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_014(0)", WagesSalariesTips.ToString());
      this.keys.Add("f1_016(0)", TaxableInterest.ToString());
      this.keys.Add("f1_018(0)", UnemploymentAlaskaDiv.ToString());
      this.keys.Add("f1_020(0)", AdjustedGrossIncome.ToString());
      this.keys.Add("c1_003(0)", this.Claimed);
      this.keys.Add("c1_004(0)", this.SpouseClaimed);
      this.keys.Add("f1_022(0)", Deduction.ToString());
      this.keys.Add("f1_024(0)", TaxableIncome.ToString());
    } // End of updatePdfDictionary() *** 

  }

  
}