using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.CategoryModule.Interface;
using Repository.Utils.BakeryRepository;

namespace Repository.CategoryModule
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly FUFlowerBouquetManagementContext _db;

        public CategoryRepository(FUFlowerBouquetManagementContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<Category> GetCategoriesBy(
            Expression<Func<Category, bool>> filter = null,
            Func<IQueryable<Category>, ICollection<Category>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Category> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return options != null ? options(query).ToList() : query.ToList();
        }

        public int GetMaxID()
        {
            return _db.Categories.Max(u => u.CategoryId) + 1;
        }
    }
}
