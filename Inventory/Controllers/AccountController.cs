using Inventory.Models;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class AccountController : Controller
   {
      public ActionResult Login()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Login(string btnSubmit, BaseAccount baseAccount)
      {

         string LoginMsg = "";

         if (btnSubmit == "Login")
         {
            bool verifyStatus = baseAccount.VerifyLogin();

            if (verifyStatus)
            {
               Session["User"] = baseAccount.UserName;
               LoginMsg = "Login Success";

               return RedirectToAction("Dashboard", "Home");
            }
            else
            {
               LoginMsg = "Failed, Username/Password not match";
            }
         }
         else if (btnSubmit == "Forget Password")
         {
            return RedirectToAction("forget", "Account");
         }

         ViewBag.LoginMsg = LoginMsg;

         return View();
      }

      //public ActionResult ForgetPassword(string btnSubmit)
      //{
      //    if (btnSubmit == "Forget Password")
      //    {
      //        return RedirectToAction("forget", "Account");
      //    }
      //    return RedirectToAction("Login", "Account"); 
      //}

      public ActionResult Forget()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Logout()
      {
         Session["User"] = null;
         return RedirectToAction("Login", "Account");
      }
   }
}