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
    }
}