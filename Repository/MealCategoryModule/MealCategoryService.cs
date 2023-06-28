using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.MealCategoryModule.Interface;

namespace Repository.MealCategoryModule
{
    public class MealCategoryService : IMealCategoryService
    {
        private readonly IMealCategoryRepository _MealCategoryRepository;

        public MealCategoryService(IMealCategoryRepository MealCategoryRepository)
        {
            _MealCategoryRepository = MealCategoryRepository;
        }
        public ICollection<MealCategory> GetAll()
        {
            return _MealCategoryRepository.GetAll().ToList();
        }
        public ICollection<MealCategory> GetCategoriesBy(Expression<Func<MealCategory, bool>> filter = null,
            Func<IQueryable<MealCategory>, ICollection<MealCategory>> options = null,
            string includeProperties = null)
        {
            return _MealCategoryRepository.GetCategoriesBy(filter);
        }
        public async Task AddNewMealCategory(MealCategory newMealCategory)
        {
            newMealCategory.MealCategoryId = _MealCategoryRepository.GetMaxID();
            await _MealCategoryRepository.AddAsync(newMealCategory);
        }
        public async Task UpdateMealCategory(MealCategory MealCategoryUpdate)
        {
            await _MealCategoryRepository.UpdateAsync(MealCategoryUpdate);
        }
        public async Task DeleteMealCategory(int id)
        {
            MealCategory MealCategoryDelete = _MealCategoryRepository.GetFirstOrDefaultAsync(x => x.MealCategoryId.Equals(id)).Result;
            if (MealCategoryDelete == null) return;
            await _MealCategoryRepository.RemoveAsync(MealCategoryDelete);
        }
        public MealCategory GetMealCategoryByID(int cateID)
        {
            return _MealCategoryRepository.GetFirstOrDefaultAsync(x => x.MealCategoryId.Equals(cateID)).Result;
        }
    }
}
