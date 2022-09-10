using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.OrderDTOs;
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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService()
        {
            _orderDetailRepository = new OrderDetailRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<OrderDetail>> CreateAsync(OrderDetailCreationDTO entity)
        {

            var response = new BaseResponse<OrderDetail>();

            var entityToCreate = _mapper.Map<OrderDetail>(entity);

            entityToCreate.Create();

            response.Data = await _orderDetailRepository.CreateAsync(entityToCreate);

            await _orderDetailRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<OrderDetail, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _orderDetailRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _orderDetailRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<OrderDetail>>> GetAllAsync(Expression<Func<OrderDetail, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<OrderDetail>>();

            response.Data = _orderDetailRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<OrderDetail>> GetAsync(Expression<Func<OrderDetail, bool>> expression)
        {
            var response = new BaseResponse<OrderDetail>();

            response.Data = await _orderDetailRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<OrderDetail>> UpdateAsync(long id, OrderDetailCreationDTO entity)
        {
            var response = new BaseResponse<OrderDetail>();

            var entityToUpdate = await _orderDetailRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _orderDetailRepository.Update(entityToUpdate);

            await _orderDetailRepository.SaveChangesAsync();

            return response;
        }
    }
}
