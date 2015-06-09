using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    public partial class GestionCategorias : System.Web.UI.Page
    {
        FACTURACIONEntities db = new FACTURACIONEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            gvCategorias.DataSource = db.Set<CATEGORIA>().Local;
            gvCategorias.DataBind();
        }



    }
}