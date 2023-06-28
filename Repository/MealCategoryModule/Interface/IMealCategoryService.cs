using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.MealCategoryModule.Interface
{
    public interface IMealCategoryService
    {
        public Task AddNewMealCategory(MealCategory newMealCategory);
        public Task UpdateMealCategory(MealCategory MealCategoryUpdate);
        public Task DeleteMealCategory(int ID);
        public ICollection<MealCategory> GetAll();
        public ICollection<MealCategory> GetCategoriesBy(Expression<Func<MealCategory, bool>> filter = null,
            Func<IQueryable<MealCategory>, ICollection<MealCategory>> options = null,
            string includeProperties = null);
        public MealCategory GetMealCategoryByID(int cateID);
    }
}
