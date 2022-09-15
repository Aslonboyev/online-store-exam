using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Mappers;
using System.Linq.Expressions;

namespace OnlineStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService()
        {
            _productRepository = new ProductRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<Product>> CreateAsync(ProductCreationDTO entity)
        {

            var response = new BaseResponse<Product>();

            if (await _productRepository.GetAsync(p => p.Name == entity.Name) is not null)
            {
                response.Error = new ErrorResponse(400, "Client is already exists");

                return response;
            }

            var entityToCreate = _mapper.Map<Product>(entity);

            entityToCreate.Create();

            response.Data = await _productRepository.CreateAsync(entityToCreate);

            await _productRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _productRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _productRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IQueryable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            var response = new BaseResponse<IQueryable<Product>>();

            response.Data = _productRepository.GetAll(expression)
                .Where(p => p.ItemState != ItemState.Deleted)
                    .Include(c => c.Category);

            return response;
        }

        public async Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var response = new BaseResponse<Product>();

            response.Data = await _productRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Product>> UpdateAsync(long id, ProductCreationDTO entity)
        {
            var response = new BaseResponse<Product>();

            var entityToUpdate = await _productRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _productRepository.Update(entityToUpdate);

            await _productRepository.SaveChangesAsync();

            return response;
        }
    }
}
