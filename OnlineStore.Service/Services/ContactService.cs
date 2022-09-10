using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Contacts;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.ContactDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService()
        {
            _contactRepository = new ContactRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        public async Task<BaseResponse<Contact>> CreateAsync(ContactCreationDTO entity)
        {
            var response = new BaseResponse<Contact>();

            if (await _contactRepository.GetAsync(p => p.Email == entity.Email || 
                                                  p.InstagramName == entity.InstagramName || 
                                                  p.Phone == entity.Phone || 
                                                  p.TelegramName == entity.TelegramName ||
                                                  p.FacebookName == entity.FacebookName) is not null)
            {
                response.Error = new ErrorResponse(400, "Client is already exists");

                return response;
            }

            var entityToCreate = _mapper.Map<Contact>(entity);

            entityToCreate.Create();

            response.Data = await _contactRepository.CreateAsync(entityToCreate);

            await _contactRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Contact, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _contactRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _contactRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<Contact>>> GetAllAsync(Expression<Func<Contact, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Contact>>();

            response.Data = _contactRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<Contact>> GetAsync(Expression<Func<Contact, bool>> expression)
        {
            var response = new BaseResponse<Contact>();

            response.Data = await _contactRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Contact>> UpdateAsync(long id, ContactCreationDTO entity)
        {
            var response = new BaseResponse<Contact>();

            var entityToUpdate = await _contactRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _contactRepository.Update(entityToUpdate);

            await _contactRepository.SaveChangesAsync();

            return response;
        }
    }
}
