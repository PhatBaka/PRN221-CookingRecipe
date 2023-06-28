using Repository.MealModule.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Repository.MealCategoryModule.Interface;
using DataAccess.Models;
using Repository.MealDetailModule.Interface;
using Repository.RecipeModule.Interface;

namespace Repository.MealModule
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMealDetailService _MealDetailRepository;
        private readonly IMealCategoryService _categoryRepository;

        public MealService(IMealRepository eventRepository, IMealCategoryService categoryRepository, IMealDetailService MealDetailRepository)
        {
            _mealRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _MealDetailRepository = MealDetailRepository;
        }

        public ICollection<Meal> GetNewestPosts(int quantity)
        {
            var list = _mealRepository.GetAll(options: o =>
                o.OrderByDescending(p => p.DateCreated).Where(x => x.Status == true).Take(quantity).ToList());
            return (list);
        }

        public ICollection<Meal> GetPostsByName(string name,
            Func<IQueryable<Meal>, ICollection<Meal>> options = null,
            string includeProperties = null)
        {
            return _mealRepository.GetPostsBy(
                x => string.Equals(x.MealName, name, StringComparison.OrdinalIgnoreCase) && x.Status == true,
                options,
                includeProperties
            );
        }

        public ICollection<Meal> GetPostsByCategory(int? categoryID)
        {
            return _mealRepository
                .GetAll()
                .Join(
                    _categoryRepository.GetAll(),
                    x => x.MealCategoryId,
                    y => y.MealCategoryId,
                    (x, y) => new { _post = x }
                )
                .Select(x => x._post)
                .Where(x => (bool)x.Status)
                .ToList();
        }

        public async Task<Meal> GetMealByID(int? postId)
        {
            return await _mealRepository.GetFirstOrDefaultAsync(
                x => x.MealId.Equals(postId),
                includeProperties: "Category,Comments"
            );
        }

        public ICollection<Meal> GetAll()
        {
            ICollection<Meal> posts = _mealRepository.GetAll(includeProperties: "Category");
            if (posts != null) return posts.ToList();
            return null;
        }

        public void AddNewPost(Meal newMeal, string uid, ICollection<MealDetail> details)
        {
            int _uid = int.Parse(uid);
            newMeal.DateCreated = DateTime.Now;
            newMeal.MealId = _mealRepository.GetMaxID() + 1;
            newMeal.AccountId = _uid;
            newMeal.Status = true;
            _mealRepository.Add(newMeal);
            foreach(MealDetail detail in details)
            {
                detail.Recipe = null;
                detail.MealId = newMeal.MealId;
            }
            _MealDetailRepository.AddNewMealDetails(details);

        }

        public async Task UpdatePost(Meal postUpdate)
        {
            await _mealRepository.UpdateAsync(postUpdate);
        }

        public async Task DeletePost(int? id)
        {
            Meal eventDelete = await _mealRepository.GetFirstOrDefaultAsync(
                x => x.MealId.Equals(id) && x.Status == true
            );
            if (eventDelete == null) return;
            eventDelete.Status = false;
            if (eventDelete != null) await _mealRepository.UpdateAsync(eventDelete);
        }
    }
}
