using DataAccess.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Repository.RecipeDetailModule.Interface
{
    public interface IRecipeDetailService
    {
        public ICollection<RecipeDetail> GetRecipeDetailByPostId(int? postId);
        public Task AddNewRecipeDetails(ICollection<RecipeDetail> RecipeDetails);
        public Task UpdateRecipeDetail(ICollection<RecipeDetail> updateRecipeDetails);
        public Task DeleteRecipeDetail(ICollection<RecipeDetail> deleteRecipeDetails);
    }
}
