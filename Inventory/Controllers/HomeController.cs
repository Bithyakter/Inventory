using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Dashboard()
      {
         if (Session["User"] != null)
         {
            List<BaseEquipment> plstData = BaseEquipment.ListEquipmentData();
            ViewBag.plstData = plstData;
            ViewBag.txtName = "";
            return View();
         }
         else
         {
            return RedirectToAction("Login", "Account");
         }
      }

      [HttpPost]
      public ActionResult Dashboard(FormCollection frm, string btnSubmit)
      {
         if (btnSubmit == "Save Equipment")
         {
            BaseEquipment baseEquipment = new BaseEquipment();
            baseEquipment.Name = frm["ddlEquipmentName"].ToString();
            baseEquipment.EcCount = Convert.ToInt32(frm["txtQuantity"].ToString());//
            baseEquipment.EntryDate = Convert.ToDateTime(frm["txtEntryDate"].ToString());

            int returnresult = baseEquipment.SaveEquipment();

            if (returnresult > 0)
            {
               ViewBag.OperationResult = "Save Successfully";
            }
         }

         List<BaseEquipment> plstData = BaseEquipment.ListEquipmentData();
         ViewBag.plstData = plstData;
         ViewBag.txtName = "";
         if (btnSubmit == "Search")
         {
            ViewBag.txtName = frm["txtName"].ToString();
         }
         ViewBag.FormCollection = frm;
         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your application description page.";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }

      public DataTable CreateTable()
      {
         DataTable dtable = new DataTable();
         dtable.Columns.Add("SNO", typeof(int));
         dtable.Columns.Add("Name", typeof(string));
         dtable.Columns.Add("Count", typeof(string));
         dtable.Columns.Add("Date", typeof(DateTime));

         dtable.Rows.Add(1, "Siva", "TUP", DateTime.Now);
         dtable.Rows.Add(2, "Raman", "MAS", DateTime.Now);
         dtable.Rows.Add(3, "Sivaraman", "TRY", DateTime.Now);
         dtable.Rows.Add(4, "Kuble", "MDU", DateTime.Now);
         dtable.Rows.Add(5, "Arun", "Salem", DateTime.Now);
         dtable.Rows.Add(6, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(7, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(8, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(9, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(10, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(1, "Siva", "TUP", DateTime.Now);
         dtable.Rows.Add(2, "Raman", "MAS", DateTime.Now);
         dtable.Rows.Add(3, "Sivaraman", "TRY", DateTime.Now);
         dtable.Rows.Add(4, "Kuble", "MDU", DateTime.Now);
         dtable.Rows.Add(5, "Arun", "Salem", DateTime.Now);
         dtable.Rows.Add(6, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(7, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(8, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(9, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(10, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(11, "Siva", "TUP", DateTime.Now);
         dtable.Rows.Add(12, "Raman", "MAS", DateTime.Now);
         dtable.Rows.Add(13, "Sivaraman", "TRY", DateTime.Now);
         dtable.Rows.Add(14, "Kuble", "MDU", DateTime.Now);
         dtable.Rows.Add(1, "Arun", "Salem", DateTime.Now);
         dtable.Rows.Add(16, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(17, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(18, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(19, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(20, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(21, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(22, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(23, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(24, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(25, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(26, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(27, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(28, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(29, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(30, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(20, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(31, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(32, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(33, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(34, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(35, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(36, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(37, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(38, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(39, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(40, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(41, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(42, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(43, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(44, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(45, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(46, "sddd", "erf", DateTime.Now);
         dtable.Rows.Add(47, "Kumar", "Erode", DateTime.Now);
         dtable.Rows.Add(48, "ghasj", "Tup", DateTime.Now);
         dtable.Rows.Add(49, "dsfd", "yercaud", DateTime.Now);
         dtable.Rows.Add(50, "dsdf", "ui", DateTime.Now);
         dtable.Rows.Add(51, "sddd", "erf", DateTime.Now);

         return dtable;
      }
   }
}