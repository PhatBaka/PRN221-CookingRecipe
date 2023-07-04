using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Repository.StepModule.Interface;
using DataAccess.Models;
using System.Linq;

namespace Repository.StepModule
{
    public class StepService : IStepService
    {
        private readonly IStepRepository _StepRepository;
        public StepService()
        {
            _StepRepository = new StepRepository();
        }
        public StepService(IStepRepository StepRepository)
        {
            _StepRepository = StepRepository;
        }

        public void AddNewStep(Step newStep)
        {
            _StepRepository.Add(newStep);
        }

        public ICollection<Step> GetAll()
        {
            return _StepRepository.GetAll();
        }

        public ICollection<Step> GetStepByRecipeId(int recipeId)
        {
            return _StepRepository.GetAll().Where(s=>s.RecipeId==recipeId).ToList();
        }

        public Task UpdateStep(Step StepUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
