using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Repository;
using AutoMapper;
using TestApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public UserService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> Auth(UserModel user)
        {
            var entity = await _dbRepository.Get<UserEntity>().FirstOrDefaultAsync(x => x.Password == user.Password && x.Email == user.Email);

            if (entity == null)
            {
                return null;
            }

            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Name = entity.Name;

            return user;
        }
        public async Task<UserModel> Register(UserModel user)
        {
            var entity = new UserEntity();
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Name = user.Name;

            var result = await _dbRepository.Add(entity);
            await _dbRepository.SaveChangesAsync();

            if (result == null)
            {
                return null;
            }

            return user;
        }
        public async Task<string> Update(UserModel user)
        {
            var entity = await _dbRepository.Get<UserEntity>().FirstOrDefaultAsync(x => x.Password == user.Password && x.Email == user.Email);

            if (entity == null)
            {
                return null;
            }

            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Name = user.Name;

            await _dbRepository.Update(entity);
            await _dbRepository.SaveChangesAsync();

            return "Successfully updated";
        }
        public async Task<string> Delete(UserModel user)
        {
            var entity = await _dbRepository.Get<UserEntity>().FirstOrDefaultAsync(x => x.Password == user.Password && x.Email == user.Email);

            if (entity == null)
            {
                return null;
            }

            await _dbRepository.Delete<UserEntity>(entity.Id);
            await _dbRepository.SaveChangesAsync();

            return "Successfully deleted";
        }
    }
}
