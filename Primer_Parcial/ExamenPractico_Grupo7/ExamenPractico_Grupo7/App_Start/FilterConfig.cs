using System.Web;
using System.Web.Mvc;

namespace ExamenPractico_Grupo7
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
