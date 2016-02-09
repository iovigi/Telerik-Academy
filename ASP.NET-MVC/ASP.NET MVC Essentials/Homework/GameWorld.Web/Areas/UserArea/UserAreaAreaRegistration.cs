using System.Web.Mvc;

namespace GameWorld.Web.Areas.UserArea
{
    public class UserAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UserArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UserArea_default",
                "User/{action}",
                new
                {
                    controller = "User",
                    action = "Index"
                }
            );
        }
    }
}