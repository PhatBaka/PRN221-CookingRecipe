using DataAccess.Models;
using Repository.StepModule.Interface;
using Repository.Utils;
using System.Linq;

namespace Repository.StepModule
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        private readonly CookingRecipeContext _db;

        public StepRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        public int GetMaxID(int recipeID)
        {
            return _db.Steps.Where(u => u.RecipeId == recipeID).Max(u => u.StepIndex ) + 1; 
        }
    }
}
