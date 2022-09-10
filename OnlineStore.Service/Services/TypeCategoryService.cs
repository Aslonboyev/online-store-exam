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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<Category>> CreateAsync(CategoryCreationDTO entity)
        {
            var response = new BaseResponse<Category>();

            if (await _categoryRepository.GetAsync(p => p.Name == entity.Name) is not null)
            {
                response.Error = new ErrorResponse(400, "Client is already exists");

                return response;
            }

            var entityToCreate = _mapper.Map<Category>(entity);

            entityToCreate.Create();

            response.Data = await _categoryRepository.CreateAsync(entityToCreate);

            await _categoryRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _categoryRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _categoryRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Category>>();

            response.Data = _categoryRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<Category>> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var response = new BaseResponse<Category>();

            response.Data = await _categoryRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Category>> UpdateAsync(long id, CategoryCreationDTO entity)
        {
            var response = new BaseResponse<Category>();

            var entityToUpdate = await _categoryRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _categoryRepository.Update(entityToUpdate);

            await _categoryRepository.SaveChangesAsync();

            return response;
        }
    }
}
