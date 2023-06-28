using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class IngredientCategory
    {
        public IngredientCategory()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int IngredientCategoryId { get; set; }
        public string IngredientCategoryName { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
