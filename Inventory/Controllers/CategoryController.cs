using Inventory.Models;
using Inventory.Services;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class CategoryController : Controller
   {
      #region Category List
      public ActionResult Categories()
      {
         CategoriesService categoriesService = new CategoriesService();
         ModelState.Clear();
         return View(categoriesService.GetAllCategories());
      }
      #endregion

      #region Create Category
      public ActionResult CreateCategory()
      {
         return View();
      }

      [HttpPost]
      public ActionResult CreateCategory(Categories category)
      {
         try
         {
            if (ModelState.IsValid)
            {
               CategoriesService categoriesService = new CategoriesService();

               if (categoriesService.AddCategory(category))
               {
                  ViewBag.Message = "Category added successfully";
               }
            }

            return View();
         }
         catch
         {
            return View();
         }
      }
      #endregion

      #region Update Category
      public ActionResult UpdateCategory(int id)
      {
         CategoriesService categoriesService = new CategoriesService();

         return View(categoriesService.GetAllCategories().Find(cat => cat.CategoryID == id));
      }

      [HttpPost]
      public ActionResult UpdateCategory(int id, Categories obj)
      {
         try
         {
            CategoriesService categoriesService = new CategoriesService();

            categoriesService.UpdateCategory(obj);
            return RedirectToAction("Categories");
         }
         catch
         {
            return View();
         }
      }
      #endregion

      #region Delete Category
      public ActionResult DeleteCategory(int id)
      {
         try
         {
            CategoriesService categoriesService = new CategoriesService();

            if (categoriesService.DeleteCategory(id))
            {
               ViewBag.AlertMsg = "Categories deleted successfully";
            }

            return RedirectToAction("Categories");
         }
         catch
         {
            return View();
         }
      }
      #endregion
   }
}