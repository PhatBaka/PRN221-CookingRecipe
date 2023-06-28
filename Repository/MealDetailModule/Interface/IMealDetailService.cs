using DataAccess.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Repository.MealDetailModule.Interface
{
    public interface IMealDetailService
    {
        public ICollection<MealDetail> GetMealDetailByMealId(int? MealDetailId);
        public Task AddNewMealDetails(ICollection<MealDetail> MealDetails);
        public Task UpdateMealDetail(ICollection<MealDetail> updateMealDetails);
        public Task DeleteMealDetail(ICollection<MealDetail> deleteMealDetails);
    }
}
