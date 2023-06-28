using DataAccess.DataModels;
using Repository.StepModule.Interface;
using Repository.Utils.BakeryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StepModule
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        private readonly CookingRecipeContext context;
        public StepRepository(CookingRecipeContext db) : base(db)
        {
            context = db;
        }
    }
}
