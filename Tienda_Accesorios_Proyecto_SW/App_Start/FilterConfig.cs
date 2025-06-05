using System.Web;
using System.Web.Mvc;

namespace Tienda_Accesorios_Proyecto_SW
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
