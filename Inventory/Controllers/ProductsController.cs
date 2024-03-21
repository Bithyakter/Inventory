using Inventory.Models;
using Inventory.Services;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class ProductsController : Controller
   {
      #region Products List
      public ActionResult ProductList()
      {
         ProductService productService = new ProductService();
         ModelState.Clear();
         ViewBag.SlNo = 1;

         return View(productService.GetAllProducts());
      }

      #endregion

      #region Create Product
      public ActionResult CreateProduct()
      {
         CategoriesService categories = new CategoriesService();
         ViewBag.Categories = categories.GetAllCategories();

         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult CreateProduct(Products product)
      {
         try
         {
            if (ModelState.IsValid)
            {
               ProductService productService = new ProductService();

               if (productService.AddProduct(product))
               {
                  ViewBag.Message = "Product added successfully";
                  //return RedirectToAction("ProductList");
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

      #region Update Product
      public ActionResult UpdateProduct(int id)
      {
         CategoriesService categories = new CategoriesService();
         ViewBag.Categories = categories.GetAllCategories();

         ProductService productService = new ProductService();

         return View(productService.GetAllProducts().Find(cat => cat.ProductID == id));
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult UpdateProduct(int? id, Products obj)
      {
         try
         {
            ProductService productService = new ProductService();

            productService.UpdateProduct(obj);
            return RedirectToAction("ProductList");
         }
         catch
         {
            return View();
         }
      }
      #endregion

      #region Delete Product
      public ActionResult DeleteProduct(int id)
      {
         try
         {
            ProductService productService = new ProductService();

            if (productService.DeleteProduct(id))
            {
               ViewBag.AlertMsg = "Products deleted successfully";
            }

            return RedirectToAction("ProductList");
         }
         catch
         {
            return View();
         }
      }
      #endregion

      public ActionResult Dashboard()
      {
         ProductService productService = new ProductService();
         ModelState.Clear();

         ViewBag.SlNo = 1;

         return View(productService.GetAllProducts());
      }
   }
}