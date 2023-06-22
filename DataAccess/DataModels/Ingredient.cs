using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataModels
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeDetails = new HashSet<RecipeDetail>();
        }

        public int IngredientId { get; set; }
        public int IngredientName { get; set; }
        public double NumberOfcalorie { get; set; }
        public int IngredientCategoryId { get; set; }

        public virtual IngredientCategory IngredientCategory { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
