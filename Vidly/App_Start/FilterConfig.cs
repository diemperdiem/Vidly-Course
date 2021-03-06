﻿using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); //para que todos los errores se manejen por la view error.html
            filters.Add(new AuthorizeAttribute()); //Para restringir globalmente el acceso al pag si se quiere dejar entrar como anonimo a alguna pestaña poner [AllowAnonimous]/algo asi
            filters.Add(new RequireHttpsAttribute()); //Adding this attribute would require that any traffic be sent over a secure channel (i.e. https) as opposed to http.
        }
    }
}
