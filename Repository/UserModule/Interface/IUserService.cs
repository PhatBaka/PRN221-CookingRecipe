using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DataAccess.Models;

namespace Repository.UserModule.Interface
{
    public interface IUserService
    {
        public Task<Customer> Authenticate(string Email, string Password);
        public Customer GetUserByUserID(int ID);
        public Task<Customer> GetUserByEmail(string Email);
        public Task AddNewUser(Customer newUser);
        public Task UpdateUser(Customer userUpdate);
        public Task ChangePassword(string newPassword, string uid);
        public Task DeleteUser(int ID);
        public ICollection<Customer> GetAll();
        public bool isExist(string email);
        //public void LikePost(Guid userId, Guid postId);
        //public void UnlikePost(Guid userId, Guid postId);
    }
}
