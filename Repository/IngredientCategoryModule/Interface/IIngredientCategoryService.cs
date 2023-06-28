using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientCategoryModule.Interface
{
    public interface IIngredientCategoryService
    {
        public ICollection<IngredientCategory> GetAll();
        public Task<IngredientCategory> GetCategoryByID(int categoryID);
    }
}
