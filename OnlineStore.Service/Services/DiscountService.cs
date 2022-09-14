using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Discounts;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.DiscountDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Mappers;
using System.Linq.Expressions;

namespace OnlineStore.Service.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService()
        {
            _discountRepository = new DiscountRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<Discount>> CreateAsync(DiscountCreationDTO entity)
        {

            var response = new BaseResponse<Discount>();

            var entityToCreate = _mapper.Map<Discount>(entity);

            entityToCreate.Create();

            response.Data = await _discountRepository.CreateAsync(entityToCreate);

            await _discountRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Discount, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _discountRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _discountRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<Discount>>> GetAllAsync(Expression<Func<Discount, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Discount>>();

            response.Data = _discountRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<Discount>> GetAsync(Expression<Func<Discount, bool>> expression)
        {
            var response = new BaseResponse<Discount>();

            response.Data = await _discountRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Discount>> UpdateAsync(long id, DiscountCreationDTO entity)
        {
            var response = new BaseResponse<Discount>();

            var entityToUpdate = await _discountRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _discountRepository.Update(entityToUpdate);

            await _discountRepository.SaveChangesAsync();

            return response;
        }
    }
}
