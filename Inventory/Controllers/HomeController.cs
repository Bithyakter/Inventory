using Inventory.Models;
using System.Diagnostics;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Login()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Login(BaseAccount baseAccount)
      {

         string LoginMsg = "";

         bool loginInfo = baseAccount.VerifyLogin();

         if (loginInfo)
         {
            Session["User"] = baseAccount.UserName;
            Debug.WriteLine("Session User: " + Session["User"]);

            LoginMsg = "Login Success";

            return RedirectToAction("Dashboard", "Products");
         }
         else
         {
            LoginMsg = "Failed, Username/Password not match";
         }

         ViewBag.LoginMsg = LoginMsg;

         return View();
      }

      [HttpPost]
      public ActionResult Logout()
      {
         Session["User"] = null;
         return RedirectToAction("Login", "Home");
      }
   }
}