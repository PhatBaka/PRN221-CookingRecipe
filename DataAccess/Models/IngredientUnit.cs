using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class IngredientUnit
    {
        public IngredientUnit()
        {
            IngredientCaloriesPerUnits = new HashSet<IngredientCaloriesPerUnit>();
            RecipeDetails = new HashSet<RecipeDetail>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<IngredientCaloriesPerUnit> IngredientCaloriesPerUnits { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
