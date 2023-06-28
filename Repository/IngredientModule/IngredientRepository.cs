using DataAccess.Models;
using Repository.IngredientModule.Interface;
using Repository.Utils;
using System.Linq;

namespace Repository.IngredientModule
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        private readonly CookingRecipeContext _db;

        public IngredientRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        public int GetMaxID()
        {
            return _db.Ingredients.Max(u => u.IngredientId ) + 1; 
        }
    }
}
