using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class UsersBAL : IUsersBAL
    {
        IUsersRepository _users;
        public UsersBAL(IUsersRepository users)
        {
            _users = users;
        }

        public Task<int> UserRegistration(Users obj)
        {
            return _users.UserRegistration(obj);
        }
        public Task<List<Users>> ValidLogin(Users obj)
        {
            return _users.ValidLogin(obj);
        }
        public Task<List<Users>> GetAllUsers()
        {
            return _users.GetAllUsers();
        }
        public Task<int> UpdateUser(Users obj)
        {
            return _users.UpdateUser(obj);
        }
        public Task<int> UpdatePwd(Users obj)
        {
            return _users.UpdatePwd(obj);
        }
        public Task<List<Users>> GetUserInfo(Users obj)
        {
            return _users.GetUserInfo(obj);
        }

        public Task<List<Users>> CheckMobileAlreadyRegisteredOrNot(Users obj)
        {
            return _users.CheckMobileAlreadyRegisteredOrNot(obj);
        }

        public Task<int> InsertOtp(OtpLog obj)
        {
            return _users.InsertOtp(obj);
        }
    }
}
