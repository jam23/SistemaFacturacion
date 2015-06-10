using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacion
{
    public static class Utilidades
    {
        public static void ShowMessage(this System.Web.UI.Page  page, SweetAlert sweetAlert)
        {
            page.Session["swal"] = sweetAlert;
        }

        public static string PasswordEncode(string plainPassword)
        {            
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainPassword));
        }

        public static string PasswordDecode(string EncodedPassword)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(EncodedPassword));
        }
    }
}