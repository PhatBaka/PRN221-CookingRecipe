using DataAccess.Models;
using Repository.Utils.Interface;

namespace Repository.StepModule.Interface
{
    public interface IStepRepository : IRepository<Step>
    {
        public int GetMaxID(int recipeID);
    }
}
