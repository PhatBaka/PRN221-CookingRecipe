using DataAccess.Models;
using Repository.Utils.Interface;
using System;
using System.Collections.Generic;

namespace Repository.RecipeDetailModule.Interface
{
    public interface IRecipeDetailRepository : IRepository<RecipeDetail>
    {
        public ICollection<RecipeDetail> GetRecipeDetailByPostId(int postId);
        public int GetMaxID();
    }
}
