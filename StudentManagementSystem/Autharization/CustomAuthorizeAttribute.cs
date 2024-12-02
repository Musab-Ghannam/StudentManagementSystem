
using System.Web.Mvc;
using System.Web;
using System;

namespace StudentManagementSystem.Autharization
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
          
            if (filterContext.HttpContext.Session["UserName"] == null)
            {

                filterContext.Result = new System.Web.Mvc.RedirectResult("~/Account/Login");
            }
        }
    }
}
