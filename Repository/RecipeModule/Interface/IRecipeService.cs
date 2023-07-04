using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Repository.RecipeModule.Interface
{
    public interface IRecipeService
    {
        //public int AddRecipe(Recipe recipe, int accountId, ICollection<RecipeDetail> details);
        public ICollection<Recipe> GetPostsByName(string name, Func<IQueryable<Recipe>, ICollection<Recipe>> options = null,
            string includeProperties = null);
        public ICollection<Recipe> GetNewestPosts(int quantity);
        public ICollection<Recipe> GetAll();
        public ICollection<Recipe> GetPostsByCategory(int? categoryID);
        public Task<Recipe> GetPostByID(int? ID);
        public int AddNewPost(Recipe newPost, string uid, ICollection<RecipeDetail> details);
        public Task UpdatePost(Recipe postUpdate);
        public Task DeletePost(int? ID);

    }
}
