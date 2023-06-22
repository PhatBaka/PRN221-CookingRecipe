using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataModels
{
    public partial class MealDetail
    {
        public int MealId { get; set; }
        public int RecipeId { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
