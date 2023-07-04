using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IngredientModule.Interface
{
    public interface IIngredientService
    {
        public Ingredient AddIngredient(Ingredient newIngredient);
        public Task<Ingredient> AddNewIngredient(Ingredient newIngredient);

        public Ingredient GetIngredientByName(string name);

        public Ingredient GetIngredientById(int CustomerId);


        public Task UpdateIngredient(Ingredient IngredientUpdate);

        public ICollection<Ingredient> GetAll();


    }
}
