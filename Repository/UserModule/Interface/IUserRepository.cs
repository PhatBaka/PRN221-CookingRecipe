using DataAccess.Models;
using Repository.Utils.Interface;

namespace Repository.UserModule.Interface
{
    public interface IUserRepository : IRepository<Account>
    {
        //public void LikePost(PostReaction _post);
        //public void UnlikePost(PostReaction _post);
        public bool isExist(string email);
        public int GetMaxID();
    }
}
