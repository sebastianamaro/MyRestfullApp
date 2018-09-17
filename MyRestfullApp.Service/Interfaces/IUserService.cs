using MyRestfullApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Service.Interfaces
{
    public interface IUserService
    {
        UserDTO AddUser(UserDTO dto);
        UserDTO UpdateUser(int id, UserDTO dto);
        void DeleteUser(int id);

        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();

    }
}
