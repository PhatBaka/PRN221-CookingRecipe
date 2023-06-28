using Repository.MealDetailModule.Interface;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Repository.Utils;

namespace Repository.MealDetailModule
{
    public class MealDetailRepository : Repository<MealDetail>, IMealDetailRepository
    {
        private readonly CookingRecipeContext _db;

        public MealDetailRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        public ICollection<MealDetail> GetMealDetailByMealId(int MealId) => _db.MealDetails.Where(x => x.MealId == MealId).ToList();
    }
}
