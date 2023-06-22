using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.CategoryModule.Interface;

namespace Repository.CategoryModule
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }
        public ICollection<Category> GetCategoriesBy(Expression<Func<Category, bool>> filter = null,
            Func<IQueryable<Category>, ICollection<Category>> options = null,
            string includeProperties = null)
        {
            return _categoryRepository.GetCategoriesBy(filter);
        }
        public async Task AddNewCategory(Category newCategory)
        {
            newCategory.CategoryId = _categoryRepository.GetMaxID();
            await _categoryRepository.AddAsync(newCategory);
        }
        public async Task UpdateCategory(Category categoryUpdate)
        {
            await _categoryRepository.UpdateAsync(categoryUpdate);
        }
        public async Task DeleteCategory(int id)
        {
            Category categoryDelete = _categoryRepository.GetFirstOrDefaultAsync(x => x.CategoryId.Equals(id)).Result;
            if (categoryDelete == null) return;
            await _categoryRepository.RemoveAsync(categoryDelete);
        }
        public Category GetCategoryByID(int cateID)
        {
            return _categoryRepository.GetFirstOrDefaultAsync(x => x.CategoryId.Equals(cateID)).Result;
        }
    }
}
