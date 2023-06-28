using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class IngredientCaloriesPerUnit
    {
        public int IngredientId { get; set; }
        public int UnitId { get; set; }
        public decimal? CaloriesPerUnit { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual IngredientUnit Unit { get; set; }
    }
}
