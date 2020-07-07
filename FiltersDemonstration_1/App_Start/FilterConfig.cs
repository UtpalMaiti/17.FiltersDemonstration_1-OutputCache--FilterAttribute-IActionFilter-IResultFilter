using FiltersDemonstration_1.UtilityClasses;
using System.Web;
using System.Web.Mvc;

namespace FiltersDemonstration_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new CustomActionFilterAttribute()); // Grobal Filder set as Application Filter it will add in App Start
        }
    }
}