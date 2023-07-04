using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.StepModule.Interface
{
    public interface IStepService
    {
        public void AddNewStep(Step newStep);


        public ICollection<Step> GetStepByRecipeId(int RecipeId);


        public Task UpdateStep(Step StepUpdate);

        public ICollection<Step> GetAll();


    }
}
