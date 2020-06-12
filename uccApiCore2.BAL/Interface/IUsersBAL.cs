using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface IUsersBAL
    {
        Task<int> UserRegistration(Users obj);
        Task<List<Users>> ValidLogin(Users obj);
    }
}
