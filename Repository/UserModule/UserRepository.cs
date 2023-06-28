using Repository.UserModule.Interface;
using DataAccess.Models;
using Repository.Utils;
using System.Linq;

namespace Repository.UserModule
{
    public class UserRepository : Repository<Account>, IUserRepository
    {
        private readonly CookingRecipeContext _db;

        public UserRepository(CookingRecipeContext db) : base(db)
        {
            _db = db;
        }

        //public void LikePost(PostReaction likeInfo)
        //{
        //    var FlowerBouquet = _db.Posts.Where(x => x.PostId.Equals(likeInfo.PostId)).FirstOrDefault();
        //    FlowerBouquet.Reaction = FlowerBouquet.Reaction + 1;
        //    _db.Posts.Attach(FlowerBouquet);
        //    _db.Entry(FlowerBouquet).Property(x => x.Reaction).IsModified = true;
        //    _db.PostReactions.Add(likeInfo);
        //    _db.SaveChanges();
        //}

        //public void UnlikePost(PostReaction likeInfo)
        //{
        //    var FlowerBouquet = _db.Posts.Where(x => x.PostId.Equals(likeInfo.PostId)).FirstOrDefault();
        //    FlowerBouquet.Reaction = FlowerBouquet.Reaction - 1;
        //    _db.Posts.Attach(FlowerBouquet);
        //    _db.Entry(FlowerBouquet).Property(x => x.Reaction).IsModified = true;
        //    _db.PostReactions.Remove(likeInfo);
        //    _db.SaveChanges();
        //}

        public bool isExist(string email)
        {
            return _db.Accounts.Any(u => u.Email == email);
        }

        public int GetMaxID()
        {
            return _db.Accounts.Max(u => u.AccountId + 1);
        }
    }
}
