using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public interface IUserService
    {
        Task<UserModel> Auth(UserModel user);
        Task<UserModel> Register(UserModel user);
        Task<string> Update(UserModel user);
        Task<string> Delete(UserModel user);
    }
}
