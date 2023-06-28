using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DataAccess.Models;

namespace Repository.UserModule.Interface
{
    public interface IUserService
    {
        public Task<Account> Authenticate(string Email, string Password);
        public Account GetUserByUserID(int ID);
        public Task<Account> GetUserByEmail(string Email);
        public Task AddNewUser(Account newUser);
        public Task UpdateUser(Account userUpdate);
        public Task ChangePassword(string newPassword, string uid);
        public Task DeleteUser(int ID);
        public ICollection<Account> GetAll();
        public bool isExist(string email);
        //public void LikePost(int userId, int postId);
        //public void UnlikePost(int userId, int postId);
    }
}
