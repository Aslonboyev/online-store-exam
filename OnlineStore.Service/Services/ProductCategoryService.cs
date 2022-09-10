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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService()
        {
            _productCategoryRepository = new ProductCategoryRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        public async Task<BaseResponse<ProductCategory>> CreateAsync(ProductCategoryCreationDTO entity)
        {

            var response = new BaseResponse<ProductCategory>();

            var entityToCreate = _mapper.Map<ProductCategory>(entity);

            entityToCreate.Create();

            response.Data = await _productCategoryRepository.CreateAsync(entityToCreate);

            await _productCategoryRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _productCategoryRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _productCategoryRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<ProductCategory>>> GetAllAsync(Expression<Func<ProductCategory, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<ProductCategory>>();

            response.Data = _productCategoryRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<ProductCategory>> GetAsync(Expression<Func<ProductCategory, bool>> expression)
        {
            var response = new BaseResponse<ProductCategory>();

            response.Data = await _productCategoryRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<ProductCategory>> UpdateAsync(long id, ProductCategoryCreationDTO entity)
        {
            var response = new BaseResponse<ProductCategory>();

            var entityToUpdate = await _productCategoryRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _productCategoryRepository.Update(entityToUpdate);

            await _productCategoryRepository.SaveChangesAsync();

            return response;
        }
    }
}
