using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<int> UserRegistration(Users obj);
        Task<List<Users>> ValidLogin(Users obj);
        Task<List<Users>> GetAllUsers();
        Task<int> UpdateUser(Users obj);
        Task<int> UpdatePwd(Users obj);
        Task<List<Users>> GetUserInfo(Users obj);
    }
}
