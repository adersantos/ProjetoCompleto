using AS.ProjetoCompleto.Infra.CrossCutting.AspNetFilters;
using System.Web;
using System.Web.Mvc;

namespace AS.ProjetoCompleto.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
