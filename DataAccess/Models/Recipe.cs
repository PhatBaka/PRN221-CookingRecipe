using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess.Models
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
        public double? AmountOfCalorie { get; set; }
        public int NumberOfStep { get; set; }
        public int Status { get; set; }
        public int AccountId { get; set; }
        public string Img { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<MealDetail> MealDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
