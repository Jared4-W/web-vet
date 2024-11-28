using System.Web;
using System.Web.Mvc;

namespace Examen1_JaredChavez
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
