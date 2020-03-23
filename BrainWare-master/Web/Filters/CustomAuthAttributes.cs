
namespace Web.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.ExceptionHandling;
    using System.Web.Http.Results;
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private bool allowed;

        public CustomAuthAttribute(bool allowedParm)
        {
            allowed = allowedParm;
        }

        protected  override bool IsAuthorized(HttpActionContext actionContext)
        {
            base.IsAuthorized(actionContext);

            if (actionContext.Request.IsLocal())
            {
                return allowed;
            }
            else
            {
                return true;
            }
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            // extract authentication Token

        }
    }

}