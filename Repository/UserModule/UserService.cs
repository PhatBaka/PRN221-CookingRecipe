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
        private readonly CookingRecipeContext _context;

        public UserService(IUserRepository userRepository, CookingRecipeContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public ICollection<Account> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public Account GetUserByUserID(int ID)
        {
            return _userRepository.GetFirstOrDefaultAsync(x => x.AccountId.Equals(ID)).Result;
        }

        public async Task AddNewUser(Account newUser)
        {
            newUser.AccountId = _userRepository.GetMaxID();
            if (await _userRepository.GetFirstOrDefaultAsync(x => x.Email.Equals(newUser.Email)) != null) return;
            await _userRepository.AddAsync(newUser);
        }

        public async Task UpdateUser(Account userUpdate)
        {
            await _userRepository.UpdateAsync(userUpdate);
        }

        public async Task ChangePassword(string newPassword, string uid)
        {
            Account Account = GetUserByUserID(int.Parse(uid));

                Account.Password = newPassword;
                _context.Entry(Account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int ID)
        {
            Account userDelete = await _userRepository.GetFirstOrDefaultAsync(x => x.AccountId.Equals(ID));
            if (userDelete == null) return;
            //userDelete.IsBlocked = true;
            await _userRepository.RemoveAsync(userDelete);
        }

        //public void LikePost(int userId, int postId)
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

        //public void UnlikePost(int userId, int postId)
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

        public Task<Account> GetUserByEmail(string Email)
        {
            return _userRepository.GetFirstOrDefaultAsync(u => u.Email.Equals(Email));
        }

        public Task<Account> Authenticate(string Email, string Password)
        {
            return _userRepository.GetFirstOrDefaultAsync(u => (u.Email == Email && u.Password == Password));
        }
    }
}
