using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class PaymentsAndTax
  {
    // Form 1040ez, Page 1, Income ...
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public int FederalIncomeTaxWithheld { get; set; }
    public int EarnedIncomeCredit_a { get; set; }
    public int NontaxableCombatPayElection { get; set; }
    public int TotalPayments { get; set; }
    public int Tax { get; set; }
    
    public void RetrieveData()
    {
      this.FederalIncomeTaxWithheld = 10000;
      this.EarnedIncomeCredit_a = 200;
      this.NontaxableCombatPayElection = 3000;
      this.TotalPayments = 40;
      this.Tax = 3400;
    } // End of RetrieveData() ***

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_026(0)", FederalIncomeTaxWithheld.ToString());
      this.keys.Add("f1_028(0)", EarnedIncomeCredit_a.ToString());
      this.keys.Add("f1_030(0)", NontaxableCombatPayElection.ToString());
      this.keys.Add("f1_032(0)", TotalPayments.ToString());
      this.keys.Add("f1_036(0)", Tax.ToString());
    } // End of updatePdfDictionary() *** 
  }
}