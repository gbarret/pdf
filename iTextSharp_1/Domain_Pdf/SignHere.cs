using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1.Domain_Pdf
{
  public class SignHere
  {
    public Dictionary<string, string> keys = new Dictionary<string, string>();

    public string Occupation { get; set; }
    public string Phone_Part_1 { get; set; }
    public string Phone_Part_2 { get; set; }
    public string SpouseOccupation { get; set; }

    public void RetrieveData()
    {
      this.Occupation = "Desk Clerk";
      this.Phone_Part_1 = "201";  // Phone.Substring(0, 3)
      this.Phone_Part_2 = "123-1234";  // Phone.Substring(4, 8)
      this.SpouseOccupation = "Doctor";
    } // End of RetrieveData() ***

    public void UpdatePdfDictionary()
    {
      this.keys.Add("f1_076(0)", Occupation);
      this.keys.Add("f1_077(0)", Phone_Part_1);
      this.keys.Add("f1_078(0)", Phone_Part_2);
      this.keys.Add("f1_079(0)", SpouseOccupation);
    } // End of updatePdfDictionary() *** 

  }
}