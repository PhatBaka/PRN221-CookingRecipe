using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientCaloriesPerUnits = new HashSet<IngredientCaloriesPerUnit>();
            RecipeDetails = new HashSet<RecipeDetail>();
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int IngredientCategoryId { get; set; }

        public virtual IngredientCategory IngredientCategory { get; set; }
        public virtual ICollection<IngredientCaloriesPerUnit> IngredientCaloriesPerUnits { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
