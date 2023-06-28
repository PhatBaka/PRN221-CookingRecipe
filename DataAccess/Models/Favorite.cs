using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Favorite
    {
        public int AccountId { get; set; }
        public int RecipeId { get; set; }
        public DateTime TimeUpdated { get; set; }

        public virtual Account Account { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
