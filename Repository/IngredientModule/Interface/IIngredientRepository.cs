using DataAccess.Models;
using Repository.Utils.Interface;

namespace Repository.IngredientModule.Interface
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        public int GetMaxID();
    }
}
