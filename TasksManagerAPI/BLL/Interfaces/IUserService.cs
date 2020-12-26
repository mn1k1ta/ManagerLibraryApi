using BLL.Helpers;
using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> CreateUserAsync(UserModelDTO user);
        Task<OperationDetails> DeleteUserAsync(int id);
        Task<OperationDetails> EditUserAsync(UserModelDTO userDTO);
        Task<ICollection<UserModelDTO>> GetAllUsersAsync();
        Task<UserModelDTO> GetUserByIdAsync(int id);
        Task<ICollection<UserModelDTO>> GetAllUsersSortByNameAsync();
        Task<ICollection<UserModelDTO>> GetAllUsersSortByLastNameAsync();
        Task<ICollection<UserModelDTO>> GetAllUsersSortByGroupAsync();
    }
}
