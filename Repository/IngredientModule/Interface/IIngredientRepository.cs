using DataAccess.DataModels;
using Repository.Utils.BakeryRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientModule.Interface
{
    public interface IIngredientRepository:IRepository<Ingredient>
    {
    }
}
