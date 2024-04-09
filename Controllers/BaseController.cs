using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTLONKY5.Controllers
{
	public class BaseController : Controller
	{
		public string CurrentUser
		{
			get
			{
				return HttpContext.Session.GetString("USER_NAME");
			}
			set
			{
				HttpContext.Session.SetString("USER_NAME", value);
			}
		}
		public bool IsLogin
		{

			get
			{
				return !string.IsNullOrEmpty(CurrentUser);
			}

		}
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
		}
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			//var isAdmin = HttpContext.Session.GetString("isAdmin");
			//ViewBag.isAdmin = isAdmin;
			ViewBag.UserName = CurrentUser;
		}
	}
}
