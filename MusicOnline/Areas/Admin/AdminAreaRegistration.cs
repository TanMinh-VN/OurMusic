using System.Web.Mvc;

namespace MusicOnline.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_login",
                "Admin/verify",
                new { action = "Index", controller = "Verify", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index",controller="DashBoard", id = UrlParameter.Optional }
            );
            
        }
    }
}