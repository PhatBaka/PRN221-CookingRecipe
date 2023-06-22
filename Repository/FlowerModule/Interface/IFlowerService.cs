using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Repository.PostModule.Interface
{
    public interface IFlowerService
    {
        public ICollection<FlowerBouquet> GetPostsByName(string name, Func<IQueryable<FlowerBouquet>, ICollection<FlowerBouquet>> options = null,
            string includeProperties = null);
        public ICollection<FlowerBouquet> GetNewestPosts(int quantity);
        public ICollection<FlowerBouquet> GetAll();
        public ICollection<FlowerBouquet> GetPostsByCategory(int categoryID);
        public Task<FlowerBouquet> GetPostByID(int ID);
        public void AddNewPost(FlowerBouquet newPost);
        public Task UpdatePost(FlowerBouquet postUpdate);
        public Task DeletePost(int ID);
    }
}
