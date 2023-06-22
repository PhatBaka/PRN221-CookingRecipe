using Repository.PostModule.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Repository.CategoryModule.Interface;
using DataAccess.Models;

namespace Repository.PostModule
{
    public class FlowerService : IFlowerService
    {
        private readonly IFlowerRepository _FlowerRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FlowerService(IFlowerRepository eventRepository, ICategoryRepository categoryRepository)
        {
            _FlowerRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public ICollection<FlowerBouquet> GetNewestPosts(int quantity)
        {
            var list = _FlowerRepository.GetAll(options: o =>
                o.OrderByDescending(p => p.FlowerBouquetId).Take(quantity).ToList());
            return (list);
        }

        public ICollection<FlowerBouquet> GetPostsByName(string name,
            Func<IQueryable<FlowerBouquet>, ICollection<FlowerBouquet>> options = null,
            string includeProperties = null)
        {
            return _FlowerRepository.GetPostsBy(
                x => string.Equals(x.FlowerBouquetName, name, StringComparison.OrdinalIgnoreCase),
                options,
                includeProperties
            );
        }

        public ICollection<FlowerBouquet> GetPostsByCategory(int categoryID)
        {
            return _FlowerRepository
                .GetAll()
                .Join(
                    _categoryRepository.GetAll(),
                    x => x.CategoryId,
                    y => y.CategoryId,
                    (x, y) => new { _post = x }
                )
                .Select(x => x._post)
                .ToList();
        }

        public async Task<FlowerBouquet> GetPostByID(int postId)
        {
            return await _FlowerRepository.GetFirstOrDefaultAsync(
                x => x.FlowerBouquetId.Equals(postId)
            );
        }

        public ICollection<FlowerBouquet> GetAll()
        {
            ICollection<FlowerBouquet> posts = _FlowerRepository.GetAll(includeProperties: "Category");
            if (posts != null) return posts.ToList();
            return null;
        }

        public void AddNewPost(FlowerBouquet newFlower)
        {
            newFlower.FlowerBouquetId = _FlowerRepository.GetMaxID();
            _FlowerRepository.Add(newFlower);
        }

        public async Task UpdatePost(FlowerBouquet postUpdate)
        {
            await _FlowerRepository.UpdateAsync(postUpdate);
        }

        public async Task DeletePost(int id)
        {
            FlowerBouquet eventDelete = await _FlowerRepository.GetFirstOrDefaultAsync(
                x => x.FlowerBouquetId.Equals(id)
            );
            if (eventDelete == null) return;
            if (eventDelete != null) await _FlowerRepository.RemoveAsync(eventDelete);
        }

    }
}
