using System.Collections.Generic;

namespace Inventory.Models
{
   public class Categories
   {
      public int CategoryID { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public virtual IEnumerable<Products> Products { get; set; }
   }
}