using Repository.RecipeDetailModule.Interface;
using Repository.MealModule.Interface;
using Repository.IngredientModule.Interface;
using DataAccess.Models;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.RecipeDetailModule
{
    public class RecipeDetailService : IRecipeDetailService
    {
        private readonly IRecipeDetailRepository _RecipeDetailRepository;
        private readonly IIngredientRepository _productRepository;
        private readonly IRecipeDetailRepository _postRepository;

        public RecipeDetailService(IRecipeDetailRepository RecipeDetailRepository, IIngredientRepository productRepository, IRecipeDetailRepository postRepository)
        {
            _RecipeDetailRepository = RecipeDetailRepository;
            _productRepository = productRepository;
            _postRepository = _postRepository;
        }

        public ICollection<RecipeDetail> GetRecipeDetailByPostId(int? postId)
        {
            if (postId == null)
            {
                return null;
            }
            else return _RecipeDetailRepository.GetRecipeDetailByPostId((int)postId);
        }

        public async Task AddNewRecipeDetails(ICollection<RecipeDetail> RecipeDetails)
        {
            //for(int i=0; i < RecipeDetails.Count-1; i++)
            //{
            //    if (RecipeDetails.ElementAt(i).PostId != RecipeDetails.ElementAt(i + 1).PostId) return;
            //}
            await _RecipeDetailRepository.AddRangeAsync(RecipeDetails);
        }
        public async Task UpdateRecipeDetail(ICollection<RecipeDetail> updateRecipeDetails)
        {
            //for (int i = 0; i < updateRecipeDetails.Count - 1; i++)
            //{
            //    if (updateRecipeDetails.ElementAt(i).PostId != updateRecipeDetails.ElementAt(i + 1).PostId) return;
            //}
            //if (_postRepository.GetFirstOrDefaultAsync(x => x.PostId == updateRecipeDetails.First().PostId) == null) return;
            //foreach (var item in updateRecipeDetails)
            //{
            //    if (_productRepository.GetFirstOrDefaultAsync(x => x.ProductId == item.ProductId) == null) return;
            //}
            await _RecipeDetailRepository.UpdateRangeAsync(updateRecipeDetails);
        }
        public async Task DeleteRecipeDetail(ICollection<RecipeDetail> deleteRecipeDetails)
        {
            //for (int i = 0; i < deleteRecipeDetails.Count - 1; i++)
            //{
            //    if (deleteRecipeDetails.ElementAt(i).PostId != deleteRecipeDetails.ElementAt(i + 1).PostId) return;
            //}
            //if (_postRepository.GetFirstOrDefaultAsync(x => x.PostId == deleteRecipeDetails.First().PostId) == null) return;
            //foreach (var item in deleteRecipeDetails)
            //{
            //    if (_productRepository.GetFirstOrDefaultAsync(x => x.ProductId == item.ProductId) == null) return;
            //}
            await _RecipeDetailRepository.RemoveRangeAsync(deleteRecipeDetails);
        }
    }
}
