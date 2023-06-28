using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class MealCategory
    {
        public MealCategory()
        {
            Meals = new HashSet<Meal>();
        }

        public int MealCategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
