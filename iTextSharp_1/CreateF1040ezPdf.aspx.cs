using iTextSharp.text.pdf;
using iTextSharp_1.Domain_Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTextSharp_1
{
  public partial class CreateF1040ezPdf : System.Web.UI.Page
  {
    int SLV_Refund = 1230;  // For Testing ...
    int SLV_AmountOwe = 0;  // For Testing ...
    int SLV_FilingStatus = 2;  // For Testing ...

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void taxYearsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string taxYear = taxYearsListBox.SelectedValue;
      resultsLabel.Text = string.Empty;

      fillingForm1040ez(taxYear);
      resultsLabel.Text = "The PDF file has been generated successfully;";
    }

    void fillingForm1040ez( string taxYear)
    {
      string inputPdfFile;
      string outputPdfFile;
      int myFormFields = 0;
      string path = MapPath(".");
      path = path.Substring(0, path.LastIndexOf("\\"));
      // Response.Write("<br>path = " + path);
      // First a input pdf file should be assigned
      //inputPdfFile = path + "/Pdfs/f1040ez--" + taxYear + ".pdf";  // "~/Pdfs/f1040ez--2007.pdf";
      inputPdfFile = "~/Pdfs/f1040ez--" + taxYear + ".pdf";
      string inputPdfTemplate = Server.MapPath(inputPdfFile);

      //outputPdfFile = path + "/PdfsOutput/2007_1040ez_" + DateTime.Now + ".pdf";
      outputPdfFile = "~/Pdfs_Output/2007_1040ez" + ".pdf";
      string outputPdfTemplate = Server.MapPath(outputPdfFile);
      //Form form = new Form(inputPdfFile, outputPdfFile);
      PdfReader myPdfReader = new PdfReader(inputPdfTemplate);
      // 20170704 ... myPdfReader.SelectPages("2"); // Page2 is not required
      // 20170704 Mail Only Page 1 of Form 1040ez and copy of the W2s ...
      myPdfReader.SelectPages("1");   // Pages to keep .. in this case Page 1 .. it removes the other pages
      myFormFields = myPdfReader.AcroFields.Fields.Count;
      // Creating the Output file ************   
      PdfStamper myPdfStamper = new PdfStamper(myPdfReader, new FileStream(outputPdfTemplate, FileMode.Create));
      AcroFields myPdfFormFields = myPdfStamper.AcroFields;
     LABEL_FillingPdfFields:
      myPdfFormFields.SetField("f1_015(0)", "01");
      myPdfFormFields.SetField("f1_017(0)", "02");
      myPdfFormFields.SetField("f1_019(0)", "03");
      myPdfFormFields.SetField("f1_021(0)", "04");
      myPdfFormFields.SetField("f1_023(0)", "05");
      myPdfFormFields.SetField("f1_025(0)", "06");
      myPdfFormFields.SetField("f1_027(0)", "07");
      myPdfFormFields.SetField("f1_029(0)", "08");
      myPdfFormFields.SetField("f1_031(0)", "09");
      myPdfFormFields.SetField("f1_033(0)", "10");
      myPdfFormFields.SetField("f1_037(0)", "11");
      myPdfFormFields.SetField("f1_039(0)", "12");
      myPdfFormFields.SetField("f1_081(0)", "Jhon NN");
      myPdfFormFields.SetField("f1_082(0)", "La Company");
      myPdfFormFields.SetField("f1_083(0)", "12");
      myPdfFormFields.SetField("f1_084(0)", "1234567");
      myPdfFormFields.SetField("f1_085(0)", "201");
      myPdfFormFields.SetField("f1_086(0)", "123-1234");

      // Page 1. Label Taxpayer...
      LabelTaxpayer labelTaxpayer = new LabelTaxpayer();
      labelTaxpayer.RetrieveData();
      labelTaxpayer.UpdatePdfDictionary();
      for (int i = 0; i < labelTaxpayer.keys.Count; i++)
      {
        myPdfFormFields.SetField(labelTaxpayer.keys.ElementAt(i).Key, labelTaxpayer.keys.ElementAt(i).Value);
      }
      // Page 1. Label Spouse ...
      if (SLV_FilingStatus == 2)
      {
        LabelSpouse labelSpouse = new LabelSpouse();
        labelSpouse.RetrieveData();
        labelSpouse.UpdatePdfDictionary();
        for (int i = 0; i < labelSpouse.keys.Count; i++)
        {
          myPdfFormFields.SetField(labelSpouse.keys.ElementAt(i).Key, labelSpouse.keys.ElementAt(i).Value);
        }
      } // End of this if ***
      // Page 1. Address ...
      // Page 1. Label Taxpayer...
      LabelAddress labelAddress = new LabelAddress();
      labelAddress.RetrieveData();
      labelAddress.UpdatePdfDictionary();
      for (int i = 0; i < labelAddress.keys.Count; i++)
      {
        myPdfFormFields.SetField(labelAddress.keys.ElementAt(i).Key, labelAddress.keys.ElementAt(i).Value);
      }
      // Page 1. Income ...
      Income income = new Income();
      income.RetrieveData();
      income.UpdatePdfDictionary();
      for (int i = 0; i < income.keys.Count; i++)
      {
        myPdfFormFields.SetField(income.keys.ElementAt(i).Key, income.keys.ElementAt(i).Value);
      }
      // Page 1. PaymentsAndTax ...
      PaymentsAndTax paymentsAndTax = new PaymentsAndTax();
      paymentsAndTax.RetrieveData();
      paymentsAndTax.UpdatePdfDictionary();
      for (int i = 0; i < paymentsAndTax.keys.Count; i++)
      {
        myPdfFormFields.SetField(paymentsAndTax.keys.ElementAt(i).Key, paymentsAndTax.keys.ElementAt(i).Value);
      }
      if (SLV_Refund > 0)
      { 
        // Page 1. Refund ...
        RefundInfo refund = new RefundInfo();
        refund.RetrieveData();
        refund.UpdatePdfDictionary();
        for (int i = 0; i < refund.keys.Count; i++)
        {
          myPdfFormFields.SetField(refund.keys.ElementAt(i).Key, refund.keys.ElementAt(i).Value);
        }
      }
      else if (SLV_AmountOwe > 0)
      { 
        // Page 1. AmountOwe ...
        AmountYouOwe amountOwe = new AmountYouOwe();
        amountOwe.RetrieveData();
        amountOwe.UpdatePdfDictionary();
        for (int i = 0; i < amountOwe.keys.Count; i++)
        {
          myPdfFormFields.SetField(amountOwe.keys.ElementAt(i).Key, amountOwe.keys.ElementAt(i).Value);
        } // End of this for ...
      } // End of this if-else-if ***
      // Page 1. Third Party Designee ...
      ThirdParty thirdParty = new ThirdParty();
      thirdParty.RetrieveData();
      thirdParty.UpdatePdfDictionary();
      for (int i = 0; i < thirdParty.keys.Count; i++)
      {
        myPdfFormFields.SetField(thirdParty.keys.ElementAt(i).Key, thirdParty.keys.ElementAt(i).Value);
      }
      // Page 1. Sign Here ...
      SignHere signHere = new SignHere();
      signHere.RetrieveData();
      signHere.UpdatePdfDictionary();
      for (int i = 0; i < signHere.keys.Count; i++)
      {
        myPdfFormFields.SetField(signHere.keys.ElementAt(i).Key, signHere.keys.ElementAt(i).Value);
      }
      //  Page 1. Paid Preparer Use Only ...
      PaidPreparer paidPreparer = new PaidPreparer();
      paidPreparer.RetrieveData();
      paidPreparer.UpdatePdfDictionary();
      for (int i = 0; i < paidPreparer.keys.Count; i++)
      {
        myPdfFormFields.SetField(signHere.keys.ElementAt(i).Key, signHere.keys.ElementAt(i).Value);
      }
      // Page 2. Deduction-Exemption Worksheet ... This is not required for mailing ...
      // 20170704. Page 2 is not required ...
      //Flatten all the fields.
      LABEL_CreatePdf:
      // flatten the form to remove editting options, set it to false
      // to leave the form open to subsequent manual edits
      myPdfStamper.FormFlattening = true;

      // very important to keep the MemoryStream intact
      //myPdfStamper.Writer.CloseStream = false;
      // Close the pdf
      myPdfStamper.Close();

    } // End of exportPdfFields() ***

  }
}