using Repository.StepModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StepModule
{
    public class StepService:IStepService
    {
        private readonly IStepRepository stepRepository;
        public StepService(IStepRepository stepRepository)
        {
            this.stepRepository = stepRepository;
        }
    }
}
