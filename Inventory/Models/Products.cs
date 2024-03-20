using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
   public class Products
   {
      public int ProductID { get; set; }

      public string Name { get; set; }

      public decimal Price { get; set; }

      public string Description { get; set; }

      public int CategoryID { get; set; }

      [ForeignKey("CategoryID")]
      public virtual Categories Categories { get; set; }
   }
}