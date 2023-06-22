using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Repository.UserModule.Interface;
using System.Linq;

namespace Repository.UserModule
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly FUFlowerBouquetManagementContext _context;

        public UserService(IUserRepository userRepository, FUFlowerBouquetManagementContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public ICollection<Customer> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public Customer GetUserByUserID(int ID)
        {
            return _userRepository.GetFirstOrDefaultAsync(x => x.CustomerId.Equals(ID)).Result;
        }

        public async Task AddNewUser(Customer newUser)
        {
            newUser.CustomerId = _userRepository.GetMaxID();
            if (await _userRepository.GetFirstOrDefaultAsync(x => x.Email.Equals(newUser.Email)) != null) return;
            await _userRepository.AddAsync(newUser);
        }

        public async Task UpdateUser(Customer userUpdate)
        {
            await _userRepository.UpdateAsync(userUpdate);
        }

        public async Task ChangePassword(string newPassword, string uid)
        {
            Customer Customer = GetUserByUserID(int.Parse(uid));

                Customer.Password = newPassword;
                _context.Entry(Customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int ID)
        {
            Customer userDelete = await _userRepository.GetFirstOrDefaultAsync(x => x.CustomerId.Equals(ID));
            if (userDelete == null) return;
            //userDelete.IsBlocked = true;
            await _userRepository.RemoveAsync(userDelete);
        }

        //public void LikePost(Guid userId, Guid postId)
        //{
        //    var likeInfo = new PostReaction
        //    {
        //        PostId = postId,
        //        UserId = userId,
        //        CreatedDate = DateTime.Now,
        //        Status = true
        //    };
        //    _userRepository.LikePost(likeInfo);
        //}

        //public void UnlikePost(Guid userId, Guid postId)
        //{
        //    var likeInfo = _postReactionRepository.GetFirstOrDefaultAsync(
        //        item => item.PostId.Equals(postId) && item.UserId.Equals(userId)
        //    ).Result;
        //    if (likeInfo != null) _userRepository.UnlikePost(likeInfo);
        //}

        public bool isExist(string email)
        {
            return _userRepository.isExist(email);
        }

        public Task<Customer> GetUserByEmail(string Email)
        {
            return _userRepository.GetFirstOrDefaultAsync(u => u.Email.Equals(Email));
        }

        public Task<Customer> Authenticate(string Email, string Password)
        {
            return _userRepository.GetFirstOrDefaultAsync(u => (u.Email == Email && u.Password == Password));
        }
    }
}
