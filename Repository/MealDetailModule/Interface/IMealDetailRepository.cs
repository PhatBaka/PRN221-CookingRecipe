using DataAccess.Models;
using Repository.Utils.Interface;
using System;
using System.Collections.Generic;

namespace Repository.MealDetailModule.Interface
{
    public interface IMealDetailRepository : IRepository<MealDetail>
    {
        public ICollection<MealDetail> GetMealDetailByMealId(int postId);
    }
}
