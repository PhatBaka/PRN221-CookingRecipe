using Repository.PostModule.Interface;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Repository.Utils.BakeryRepository;
using DataAccess.Models;

namespace Repository.PostModule
{
    public class FlowerRepository : Repository<FlowerBouquet>, IFlowerRepository
    {
        private readonly CookingRecipeContext _db;

        public FlowerRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        public int GetMaxID()
        {
            return _db.FlowerBouquets.Max(u => u.FlowerBouquetId) + 1;
        }

        public ICollection<FlowerBouquet> GetPostsBy(Expression<Func<FlowerBouquet, bool>> filter = null,
            Func<IQueryable<FlowerBouquet>, ICollection<FlowerBouquet>> options = null,
            string includeProperties = null)
        {
            IQueryable<FlowerBouquet> query = DbSet;

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
    }
}
