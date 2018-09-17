using MyRestfullApp.Data;
using MyRestfullApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRestfullApp.DTO;
using System.Data.Entity;

namespace MyRestfullApp.Service
{
    public class UserService : IUserService
    {
        MyRestfullAppEntities context;
        public UserService(MyRestfullAppEntities context)
        {
            this.context = context;
        }

        public UserDTO AddUser(UserDTO dto)
        {
            User user = new User();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Password = dto.Password;

            context.Users.Add(user);
            context.SaveChanges();
            dto.Id = user.Id;
            return dto;
        }

        public void DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
        

        public UserDTO GetUser(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };
            }
            else
                return null;

        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return context.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password
            }).ToList();
        }

        public UserDTO UpdateUser(int id, UserDTO dto)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                user.Password = dto.Password;
                context.SaveChanges();
                dto.Id = id;
                return dto;
            }
            else
                return null;
        }
    }
}
