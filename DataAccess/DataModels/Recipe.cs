using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataModels
{
    public partial class Recipe
    {
        public Recipe()
        {
            Favorites = new HashSet<Favorite>();
            MealDetails = new HashSet<MealDetail>();
            Ratings = new HashSet<Rating>();
            RecipeDetails = new HashSet<RecipeDetail>();
            Steps = new HashSet<Step>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Difficulty { get; set; }
        public double AmountOfCalorie { get; set; }
        public int NumberOfStep { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<MealDetail> MealDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
