using Repository.RecipeModule.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Repository.MealCategoryModule.Interface;
using DataAccess.Models;
using Repository.MealDetailModule.Interface;
using Repository.RecipeDetailModule.Interface;
using Repository.RecipeDetailModule;
using System.Security.Cryptography;

namespace Repository.RecipeModule
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _RecipeRepository;
        private readonly IRecipeDetailService _MealDetailRepository;
        private readonly IMealCategoryService _categoryRepository;

        public RecipeService()
        {
            _RecipeRepository = new RecipeRepository();
            _MealDetailRepository = new RecipeDetailService();
        }
        public RecipeService(IRecipeRepository eventRepository, IMealCategoryService categoryRepository, IRecipeDetailService MealDetailRepository)
        {
            _RecipeRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _MealDetailRepository = MealDetailRepository;
        }

        public ICollection<Recipe> GetNewestPosts(int quantity)
        {
            var list = _RecipeRepository.GetAll(options: o =>
                o.Take(quantity).ToList());
            return (list);
        }

        public ICollection<Recipe> GetPostsByName(string name,
            Func<IQueryable<Recipe>, ICollection<Recipe>> options = null,
            string includeProperties = null)
        {
            return _RecipeRepository.GetPostsBy(
                x => string.Equals(x.RecipeName, name, StringComparison.OrdinalIgnoreCase) ,
                options,
                includeProperties
            );
        }

        public ICollection<Recipe> GetPostsByCategory(int? categoryID)
        {
            //return _RecipeRepository
            //    .GetAll()
            //    .Join(
            //        _categoryRepository.GetAll(),
            //        x => x.CategoryId,
            //        y => y.CategoryId,
            //        (x, y) => new { _post = x }
            //    )
            //    .Select(x => x._post)
            //    .Where(x => (bool)x.Status)
            //    .ToList();
            return null;
        }

        public async Task<Recipe> GetPostByID(int? postId)
        {
            return await _RecipeRepository.GetFirstOrDefaultAsync(
                x => x.RecipeId.Equals(postId),
                includeProperties: "Category,Comments"
            );
        }

        public ICollection<Recipe> GetAll()
        {
            ICollection<Recipe> posts = _RecipeRepository.GetAll(includeProperties: "Category");
            if (posts != null) return posts.ToList();
            return null;
        }

        public int AddNewPost(Recipe newEvent, string uid, ICollection<RecipeDetail> details)
        {
            int _uid = int.Parse(uid);
            //newEvent.CreatedDate = DateTime.Now;
            if (GetAll()!=null)
            {
                newEvent.RecipeId = _RecipeRepository.GetMaxID() + 1;
            }
            else
            {
                newEvent.RecipeId = 1;
            }    
            newEvent.AccountId = _uid;
            //newEvent.Status = true;
            //newEvent.Reaction = 0;
            _RecipeRepository.Add(newEvent);
            foreach(RecipeDetail detail in details)
            {
                //detail.Product = null;
                detail.RecipeId = newEvent.RecipeId;
            }
            _MealDetailRepository.AddNewRecipeDetails(details);
            return newEvent.RecipeId;
        }
        //public int AddRecipe(Recipe recipe, int accountId, ICollection<RecipeDetail> details)
        //{
        //    int check= RandomNumberGenerator.GetInt32(int.MaxValue);
        //    while (GetRecipeByID(check) != null)
        //    {
        //        check++;
        //    }
        //    recipe.RecipeId = check;
        //    recipe.AccountId = accountId;
        //    _RecipeRepository.Add(recipe);
        //    foreach (RecipeDetail detail in details)
        //    {
        //        //detail.Product = null;
        //        detail.RecipeId = recipe.RecipeId;
        //    }
        //    _MealDetailRepository.AddNewRecipeDetails(details);
        //    return recipe.RecipeId;
        //}
        public Recipe GetRecipeByID(int id)
        {
            return _RecipeRepository.GetAll().FirstOrDefault(r=>r.RecipeId==id);
        }

        public async Task UpdatePost(Recipe postUpdate)
        {
            //postUpdate.UpdatedDate = DateTime.Now;
            await _RecipeRepository.UpdateAsync(postUpdate);
        }

        public async Task DeletePost(int? id)
        {
            Recipe eventDelete = await _RecipeRepository.GetFirstOrDefaultAsync(
                x => x.RecipeId.Equals(id) 
            );
            if (eventDelete == null) return;
            if (eventDelete != null) await _RecipeRepository.RemoveAsync(eventDelete);
        }
    }
}
