using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealDetails = new HashSet<MealDetail>();
        }

        public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public int? PrepareTime { get; set; }
        public int? NumberOfEater { get; set; }
        public int MealCategoryId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual MealCategory MealCategory { get; set; }
        public virtual ICollection<MealDetail> MealDetails { get; set; }
    }
}
