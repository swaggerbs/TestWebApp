using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public class UserService : IUserService
    {
        private bool IsValid(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                return false;
            }

            if (user.Password.Length < 8)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                return false;
            }
            return true;
        }
        private int GetId(UserModel user)
        {
            int result = _users.FindIndex(it => user == it);

            return result;
        }
        private UsersData _users;
        public UserService(UsersData users)
        {
            _users = users;
        }
        public UserModel Auth(UserModel user)
        {
            if (!IsValid(user) || GetId(user) == -1)
            {
                return null;
            }

            return user;
        }

        public UserModel Edit(UserModel user)
        {
            if (!IsValid(user))
            {
                return null;
            }

            int id = GetId(user);

            if (id == -1)
            {
                return null;
            }

            _users[id] = user;

            return user;
        }

        public UserModel Delete(UserModel user)
        {
            if (!IsValid(user))
            {
                return null;
            }

            int id = GetId(user);

            if (id == -1)
            {
                return null;
            }

            _users.Remove(user);

            return user;
        }

        public UserModel Register(UserModel user)
        {
            if (!IsValid(user))
            {
                return null;
            }

            _users.Add(user);

            return user;
        }
    }
}
