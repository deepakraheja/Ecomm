using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;
using static System.Data.CommandType;

namespace uccApiCore2.Repository
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public async Task<int> UserRegistration(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PASSWORD", obj.password);
                parameters.Add("@email", obj.email);
                parameters.Add("@Name", obj.Name);
                parameters.Add("@MobileNo", obj.MobileNo);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_Users_ins", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Users>> ValidLogin(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoginId", obj.LoginId);
                parameters.Add("@PASSWORD", obj.password);
                parameters.Add("@UserType", obj.UserType);
                List<Users> lst = (await SqlMapper.QueryAsync<Users>(con, "p_ValidLogin", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                List<Users> lst = (await SqlMapper.QueryAsync<Users>(con, "p_Users_sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateUser(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", obj.UserID);
                parameters.Add("@email", obj.email);
                parameters.Add("@Name", obj.Name);
                parameters.Add("@MobileNo", obj.MobileNo);

                parameters.Add("@IsActive", obj.IsActive);
                parameters.Add("@IsApproval", obj.IsApproval);
                parameters.Add("@ApprovedBy", obj.ApprovedBy);
                parameters.Add("@ApprovedDate", obj.ApprovedDate);
                parameters.Add("@AdditionalDiscount", obj.AdditionalDiscount);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_Users_upd", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdatePwd(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", obj.UserID);
                parameters.Add("@password", obj.password);
                parameters.Add("@NewPassword", obj.NewPassword);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_UpdatePwd", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<List<Users>> GetUserInfo(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", obj.UserID);
                List<Users> lst = (await SqlMapper.QueryAsync<Users>(con, "p_Users_sel_userId", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async Task<List<Users>> CheckMobileAlreadyRegisteredOrNot(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MobileNo", obj.MobileNo);
                List<Users> lst = (await SqlMapper.QueryAsync<Users>(con, "p_Users_sel_MobileNo", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async Task<int> InsertOtp(OtpLog obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MobileNo", obj.MobileNo);
                parameters.Add("@OTP", obj.OTP);
                parameters.Add("@SessionId", obj.SessionId);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_OtpLog_ins", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
