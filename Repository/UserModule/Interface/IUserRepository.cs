using DataAccess.Models;
using Repository.Utils.BakeryRepository.Interface;

namespace Repository.UserModule.Interface
{
    public interface IUserRepository : IRepository<Customer>
    {
        //public void LikePost(PostReaction _post);
        //public void UnlikePost(PostReaction _post);
        public bool isExist(string email);
        public int GetMaxID();
    }
}
