using System.Web;
using System.Web.Mvc;

namespace TehHotel.Gui.TEst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}