using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Repository.IngredientModule.Interface;
using DataAccess.Models;

namespace Repository.IngredientModule
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _IngredientRepository;
        public IngredientService()
        {
            _IngredientRepository = new IngredientRepository();
        }

        public IngredientService(IIngredientRepository IngredientRepository)
        {
            _IngredientRepository = IngredientRepository;
        }
        public Ingredient AddIngredient(Ingredient newIngredient)
        {            
            _IngredientRepository.Add(newIngredient);
            return GetIngredientByName(newIngredient.IngredientName);
        }
        public Ingredient GetIngredientByName(string name)
        {
            return _IngredientRepository.GetFirstOrDefaultAsync(x => x.IngredientName.Equals(name)).Result;
        }

        public async Task<Ingredient> AddNewIngredient(Ingredient newIngredient)
        {
            newIngredient.IngredientId = _IngredientRepository.GetMaxID();
            await _IngredientRepository.AddAsync(newIngredient);
            return  GetIngredientById(newIngredient.IngredientId);
        }

        public Ingredient GetIngredientById(int IngredientId)
        {
            return _IngredientRepository.GetFirstOrDefaultAsync(x => x.IngredientId.Equals(IngredientId)).Result;
        }

        public async Task UpdateIngredient(Ingredient IngredientUpdate)
        {
            await _IngredientRepository.UpdateAsync(IngredientUpdate);
        }

        public ICollection<Ingredient> GetAll()
        {
            ICollection<Ingredient> Ingredients =  _IngredientRepository.GetAll();
            return Ingredients;
        }
        
    }
}
