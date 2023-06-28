using Repository.MealDetailModule.Interface;
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
using Repository.RecipeModule.Interface;

namespace Repository.MealDetailModule
{
    public class MealDetailService : IMealDetailService
    {
        private readonly IMealDetailRepository _MealDetailRepository;
        private readonly IIngredientRepository _productRepository;
        private readonly IRecipeRepository _postRepository;

        public MealDetailService(IMealDetailRepository MealDetailRepository, IIngredientRepository productRepository, IRecipeRepository postRepository)
        {
            _MealDetailRepository = MealDetailRepository;
            _productRepository = productRepository;
            _postRepository = postRepository;
        }

        public ICollection<MealDetail> GetMealDetailByMealId(int? mealId)
        {
            if (mealId == null)
            {
                return null;
            }
            else return _MealDetailRepository.GetMealDetailByMealId((int)mealId);
        }

        public async Task AddNewMealDetails(ICollection<MealDetail> MealDetails)
        {
            //for(int i=0; i < MealDetails.Count-1; i++)
            //{
            //    if (MealDetails.ElementAt(i).RecipeId != MealDetails.ElementAt(i + 1).PostId) return;
            //}
            await _MealDetailRepository.AddRangeAsync(MealDetails);
        }
        public async Task UpdateMealDetail(ICollection<MealDetail> updateMealDetails)
        {
            //for (int i = 0; i < updateMealDetails.Count - 1; i++)
            //{
            //    if (updateMealDetails.ElementAt(i).PostId != updateMealDetails.ElementAt(i + 1).PostId) return;
            //}
            //if (_postRepository.GetFirstOrDefaultAsync(x => x.PostId == updateMealDetails.First().PostId) == null) return;
            //foreach (var item in updateMealDetails)
            //{
            //    if (_productRepository.GetFirstOrDefaultAsync(x => x.ProductId == item.ProductId) == null) return;
            //}
            await _MealDetailRepository.UpdateRangeAsync(updateMealDetails);
        }
        public async Task DeleteMealDetail(ICollection<MealDetail> deleteMealDetails)
        {
            //for (int i = 0; i < deleteMealDetails.Count - 1; i++)
            //{
            //    if (deleteMealDetails.ElementAt(i).PostId != deleteMealDetails.ElementAt(i + 1).PostId) return;
            //}
            //if (_postRepository.GetFirstOrDefaultAsync(x => x.PostId == deleteMealDetails.First().PostId) == null) return;
            //foreach (var item in deleteMealDetails)
            //{
            //    if (_productRepository.GetFirstOrDefaultAsync(x => x.ProductId == item.ProductId) == null) return;
            //}
            await _MealDetailRepository.RemoveRangeAsync(deleteMealDetails);
        }
    }
}
