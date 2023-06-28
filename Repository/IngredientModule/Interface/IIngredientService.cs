using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IngredientModule.Interface
{
    public interface IIngredientService
    {
        public Task<Ingredient> AddNewIngredient(Ingredient newIngredient);


        public Ingredient GetIngredientById(int CustomerId);


        public Task UpdateIngredient(Ingredient IngredientUpdate);

        public ICollection<Ingredient> GetAll();


    }
}
