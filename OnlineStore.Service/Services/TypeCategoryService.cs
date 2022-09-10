using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.CategoryDTOs;
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
    public class TypeCategoryService : ITypeCategoryService
    {
        private readonly ITypeCategoryRepository _typeCategoryRepository;
        private readonly IMapper _mapper;

        public TypeCategoryService()
        {
            _typeCategoryRepository = new TypeCategoryRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        public async Task<BaseResponse<TypeCategory>> CreateAsync(CategoryCreationDTO entity)
        {
            var response = new BaseResponse<TypeCategory>();

            if (await _typeCategoryRepository.GetAsync(p => p.Name == entity.Name) is not null)
            {
                response.Error = new ErrorResponse(400, "Client is already exists");

                return response;
            }

            var entityToCreate = _mapper.Map<TypeCategory>(entity);

            entityToCreate.Create();

            response.Data = await _typeCategoryRepository.CreateAsync(entityToCreate);

            await _typeCategoryRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<TypeCategory, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _typeCategoryRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _typeCategoryRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<TypeCategory>>> GetAllAsync(Expression<Func<TypeCategory, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<TypeCategory>>();

            response.Data = _typeCategoryRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<TypeCategory>> GetAsync(Expression<Func<TypeCategory, bool>> expression)
        {
            var response = new BaseResponse<TypeCategory>();

            response.Data = await _typeCategoryRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<TypeCategory>> UpdateAsync(long id, CategoryCreationDTO entity)
        {
            var response = new BaseResponse<TypeCategory>();

            var entityToUpdate = await _typeCategoryRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _typeCategoryRepository.Update(entityToUpdate);

            await _typeCategoryRepository.SaveChangesAsync();

            return response;
        }
    }
}
