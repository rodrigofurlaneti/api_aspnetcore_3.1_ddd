using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _userRepository;
        private readonly IMapper _autoMapper;
        public UserService(IRepository<UserEntity> userRepository, IMapper autoMapper)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }
        public async Task<UserDto> Get(Guid id)
        {
            UserEntity userEntity = await _userRepository.SelectAsync(id);
            return _autoMapper.Map<UserDto>(userEntity);
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserEntity> listUserEntity = await _userRepository.SelectAsync();
            return _autoMapper.Map<IEnumerable<UserDto>>(listUserEntity);
        }
        public async Task<UserCreateResultDto> Post(UserCreateDto user)
        {
            UserModel model = _autoMapper.Map<UserModel>(user);
            UserEntity entity = _autoMapper.Map<UserEntity>(model);
            UserEntity result = await _userRepository.InsertAsync(entity);
            return _autoMapper.Map<UserCreateResultDto>(result);
        }
        public async Task<UserUpdateResultDto> Put(UserUpdateDto user)
        {
            UserModel model = _autoMapper.Map<UserModel>(user);
            UserEntity entity = _autoMapper.Map<UserEntity>(model);
            UserEntity result = await _userRepository.UpdateAsync(entity);
            return _autoMapper.Map<UserUpdateResultDto>(result);
        }
    }
}