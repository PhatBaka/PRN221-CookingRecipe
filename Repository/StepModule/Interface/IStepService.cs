using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.StepModule.Interface
{
    public interface IStepService
    {
        public Task<Step> AddNewStep(Step newStep);


        public Step GetStepById(int CustomerId);


        public Task UpdateStep(Step StepUpdate);

        public ICollection<Step> GetAll();


    }
}
