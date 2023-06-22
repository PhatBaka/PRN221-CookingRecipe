using DataAccess.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Repository.Utils.BakeryRepository.Interface;

namespace Repository.PostModule.Interface
{
    public interface IFlowerRepository : IRepository<FlowerBouquet>
    {
        public ICollection<FlowerBouquet> GetPostsBy(
            Expression<Func<FlowerBouquet, bool>> filter = null,
            Func<IQueryable<FlowerBouquet>, ICollection<FlowerBouquet>> options = null,
            string includeProperties = null
        );
        public int GetMaxID();
    }
}
