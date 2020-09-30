using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public interface IUserService
    {
        UserModel Auth(UserModel user);
        UserModel Register(UserModel user);
        UserModel Edit(UserModel user);
        UserModel Delete(UserModel user);
    }
}
