using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Text;

namespace iTextSharp_1
{
  public partial class GetF1040Ez_FieldNames : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void taxYearsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string taxYear = taxYearsListBox.SelectedValue;
      lblPdfName.Text = string.Empty;
      lblPdfFields.Text = string.Empty;

      ListFieldNames(taxYear);
    }

    /// <summary>
    /// List all of the form fields into a textbox.  The
    /// form fields identified can be used to map each of the
    /// fields in a PDF.
    /// </summary>
    private void ListFieldNames(string taxYear)
    {
      PdfReader pdfReader;
      // string myPdfFile = "f1040ez.pdf";
      // string myPdfFile = "f1040ez_2016.pdf";
      string myPdfFile = "~/Pdfs/f1040ez--" + taxYear + ".pdf";
      //string myPdfFile = "f1040ez--2004.pdf";
      // 20170527 ... string pdfTemplate  = Server.MapPath("f1040ez.pdf");
      lblPdfName.Text = myPdfFile;
      string pdfTemplate = Server.MapPath(myPdfFile);
      int i = 0;
      Response.Write("pdfTemplate:" + pdfTemplate);
      // Create a new PDF reader based on the PDF template document
      try
      {
        pdfReader = new PdfReader(pdfTemplate);
      }
      catch(Exception ex)
      {
        lblPdfName.Text = String.Format("Error File does not exist {0}", ex.Message);
        return;
      }
      
      // create and populate a string builder with each of the
      // field names available in the subject PDF
      StringBuilder sb = new StringBuilder();
      foreach (DictionaryEntry de in pdfReader.AcroFields.Fields)
      {
        i += 1;
        //sb.Append(i + ") " + de.Key.ToString() + Environment.NewLine);
        lblPdfFields.Text += i + ") " + de.Key.ToString() + "<br>";
      }

      // Write the string builder's content to the form's textbox
      //Response.Write("<br>PDF Fields:<br>" + sb.ToString());
      //lblPdfFields.Text = sb.ToString();
      //textBox1.SelectionStart = 0;
    }

  }
}