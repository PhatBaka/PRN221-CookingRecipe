using Repository.RecipeDetailModule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RecipeDetailModule
{
    public class RecipeDetailService:IRecipeDetailService
    {
        private readonly IRecipeDetailRepository repository;
        public RecipeDetailService(IRecipeDetailRepository repository)
        {
            this.repository = repository;
        }
    }
}
