using Repository.IngredientModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IngredientModule
{
    public class IngredientService:IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;
        public IngredientService(IIngredientRepository repository)
        {
            ingredientRepository = repository;
        }
    }
}
