using DataAccess.DataModels;
using Repository.IngredientCategoryModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientCategoryModule
{
    public class IngredientCategoryService:IIngredientCategoryService
    {
        private readonly IIngredientCategoryRepository repository;
        public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository)
        {
            repository = ingredientCategoryRepository;
        }

        public ICollection<IngredientCategory> GetAll()
        {
            ICollection<IngredientCategory> result = repository.GetAll();
            if(result!=null)
                return result.ToList();
            return null;
        }

        public async Task<IngredientCategory> GetCategoryByID(int categoryID)
        {
            return await repository.GetFirstOrDefaultAsync(x=>x.IngredientCategoryId==categoryID);
        }
    }
}
