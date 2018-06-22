using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AS.ProjetoCompleto.UI.Web.Helpers
{
    public static class ClaimsHelper
    {

        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidadePermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        private static bool ValidadePermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}