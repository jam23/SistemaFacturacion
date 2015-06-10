using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace SistemaFacturacion
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("", "Vendedores/{action}/{id}", "~/Vendedores/Editar.aspx");
            //routes.MapPageRoute("", "GestionCategorias/{id}", "~/GestionCategorias.aspx");
            routes.EnableFriendlyUrls();
        }
    }
}
