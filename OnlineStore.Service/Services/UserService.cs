using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.UserDTOs;
using OnlineStore.Service.Extentions;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Mappers;
using System.Linq.Expressions;

namespace OnlineStore.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService()
        {
            _userRepository = new UserRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<User>> CreateAsync(UserCreationDTO entity)
        {

            var response = new BaseResponse<User>();


            if (await _userRepository.GetAsync(p => p.Email == entity.Email ||
                                               p.Username == entity.Username ||
                                               p.Phone == entity.Phone) is not null)
            {
                response.Error = new ErrorResponse(400, "Client is already exists");
            }

            else if(entity.Email.IsEmial() && entity.Phone.IsPhoneNumber())
            {
                var entityToCreate = _mapper.Map<User>(entity);

                entityToCreate.Create();

                entityToCreate.Password = entityToCreate.Password.GetHash();

                response.Data = await _userRepository.CreateAsync(entityToCreate);

                await _userRepository.SaveChangesAsync();
            }
            else
            {
                response.Error = new ErrorResponse(402, "User gave wrong data");
            }

            return response;

        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _userRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _userRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<User>>();

            response.Data = _userRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            response.Data = await _userRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Data = null;
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<User>> UpdateAsync(long id, UserCreationDTO entity)
        {
            var response = new BaseResponse<User>();

            var result = await _userRepository.GetAsync(p => p.Email == entity.Email ||
                p.Username == entity.Username || p.Phone == entity.Phone);

            var entityToUpdate = await _userRepository.GetAsync(p => p.Id == id);

            if (entityToUpdate is null || result is not null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");
            }

            else if (entity.Email.IsEmial() && !entity.Phone.IsPhoneNumber())
            {
                entityToUpdate = _mapper.Map(entity, entityToUpdate);

                entityToUpdate.Update();

                _userRepository.Update(entityToUpdate);

                await _userRepository.SaveChangesAsync();
            }

            return response;
        }

        public async Task<BaseResponse<User>> LogInAsync(string username, string password)
        {
            var response = new BaseResponse<User>();

            var result = await _userRepository.GetAsync(p => p.Username == username && p.ItemState != ItemState.Deleted);

            if (result is not null && result.Password == password.GetHash())
                response.Data = result;
            else
                response.Data = null;

            return response;
        }
    }
}
