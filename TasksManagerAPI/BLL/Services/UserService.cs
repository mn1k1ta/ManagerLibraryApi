using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _dataBase;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork _dataBase, IMapper _mapper)
        {
            this._dataBase = _dataBase;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> CreateUserAsync(UserModelDTO user)
        {
            if (user == null)
            {
                return new OperationDetails("User is null!", false);
            }

            _dataBase.UserModelRepository.Create(_mapper.Map<UserModel>(user));
            await _dataBase.SaveAsync();
            return new OperationDetails("User id created", true);
        }
        public async Task<OperationDetails> DeleteUserAsync(int id)
        {           
            var user = await _dataBase.UserModelRepository.GetByIdAsync(id);
            if (user == null)
            {
                return new OperationDetails("This user is not found!", false);
            }
            foreach (var item in await _dataBase.TaskModelRepository.GetWhereAsync(x=>x.UserModel.UserId==user.UserId))
            {
                item.DocumentStatus = DocumentStatus.InLibrary;
                item.UserModelId = null;
                _dataBase.TaskModelRepository.Update(item);               
            }
            //await _dataBase.SaveAsync();
            _dataBase.UserModelRepository.Delete(user);
            await _dataBase.SaveAsync();
            return new OperationDetails("User id deleted!", true);
        }
        public async Task<OperationDetails> EditUserAsync(UserModelDTO userDTO)
        {
            if (userDTO == null)
            {
                return new OperationDetails("User is null!", false);
            }
            var user = await _dataBase.UserModelRepository.GetByIdAsync(userDTO.UserId);
            if (user == null)
            {
                return new OperationDetails("This user is not found!", false);
            }
            _dataBase.UserModelRepository.Update(_mapper.Map(userDTO,user));
            await _dataBase.SaveAsync();
            return new OperationDetails("User id updated!", true);
        }
        public async Task<ICollection<UserModelDTO>> GetAllUsersAsync()
        {
            return  _mapper.Map<ICollection<UserModelDTO>>(await _dataBase.UserModelRepository.GetAllAsync());
        }
        public async Task<UserModelDTO> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserModelDTO>(await _dataBase.UserModelRepository.GetByIdAsync(id));
        }
        public async Task<ICollection<UserModelDTO>> GetAllUsersSortByNameAsync()
        {
            return _mapper.Map<ICollection<UserModelDTO>>(await _dataBase.UserModelRepository.GetAllAsync()).OrderBy(x => x.FirstName).ToList();
        }
        public async Task<ICollection<UserModelDTO>> GetAllUsersSortByLastNameAsync()
        {
            return _mapper.Map<ICollection<UserModelDTO>>(await _dataBase.UserModelRepository.GetAllAsync()).OrderBy(x => x.LastName).ToList();
        }
        public async Task<ICollection<UserModelDTO>> GetAllUsersSortByGroupAsync()
        {
            return _mapper.Map<ICollection<UserModelDTO>>(await _dataBase.UserModelRepository.GetAllAsync()).OrderBy(x => x.Group).ToList();
        }
    }
}
