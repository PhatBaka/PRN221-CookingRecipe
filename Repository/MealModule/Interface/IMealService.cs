using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Repository.MealModule.Interface
{
    public interface IMealService
    {
        public ICollection<Meal> GetPostsByName(string name, Func<IQueryable<Meal>, ICollection<Meal>> options = null,
            string includeProperties = null);
        public ICollection<Meal> GetNewestPosts(int quantity);
        public ICollection<Meal> GetAll();
        public ICollection<Meal> GetPostsByCategory(int? categoryID);
        public Task<Meal> GetMealByID(int? ID);
        public void AddNewPost(Meal newPost, string uid, ICollection<MealDetail> details);
        public Task UpdatePost(Meal postUpdate);
        public Task DeletePost(int? ID);
    }
}
