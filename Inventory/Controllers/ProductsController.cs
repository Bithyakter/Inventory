using Inventory.Models;
using Inventory.Services;
using System.Web.Mvc;

namespace Inventory.Controllers
{
   public class ProductsController : Controller
   {
      #region Products List
      public ActionResult Products()
      {
         ProductService productService = new ProductService();
         ModelState.Clear();
         return View(productService.GetAllProducts());
      }
      #endregion

      #region Create Product
      public ActionResult CreateProduct()
      {
         return View();
      }

      [HttpPost]
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
         ProductService productService = new ProductService();

         return View(productService.GetAllProducts().Find(cat => cat.ProductID == id));
      }

      [HttpPost]
      public ActionResult UpdateProduct(int id, Products obj)
      {
         try
         {
            ProductService productService = new ProductService();

            productService.UpdateProduct(obj);
            return RedirectToAction("Products");
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

            return RedirectToAction("Products");
         }
         catch
         {
            return View();
         }
      }
      #endregion
   }
}