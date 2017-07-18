using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTextSharp_1
{
  public static class stringExtensions
  {
    public static string MyName(this string Name)
    {
      return "Your Name is " + Name;
    }
  }
}