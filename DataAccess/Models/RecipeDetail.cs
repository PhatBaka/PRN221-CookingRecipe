using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class RecipeDetail
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public string Note { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual IngredientUnit Unit { get; set; }
    }
}
