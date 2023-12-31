﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            Favorites = new HashSet<Favorite>();
            Meals = new HashSet<Meal>();
            Ratings = new HashSet<Rating>();
            Recipes = new HashSet<Recipe>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Status { get; set; }
        public DateTime TimeJoined { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
