using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Enums;
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
    public class OrderService : IOrderService
    {

        readonly IOrderRepository _orderRepository;
        readonly IMapper _mapper;

        public OrderService()
        {
            _orderRepository = new OrderRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        public async Task<BaseResponse<Order>> CreateAsync(OrderCreationDTO entity)
        {

            var response = new BaseResponse<Order>();

            var entityToCreate = _mapper.Map<Order>(entity);

            entityToCreate.Create();

            response.Data = await _orderRepository.CreateAsync(entityToCreate);

            await _orderRepository.SaveChangesAsync();

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _orderRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _orderRepository.SaveChangesAsync();

            response.Data = true;

            return response;

        }

        public async Task<BaseResponse<IEnumerable<Order>>> GetAllAsync(Expression<Func<Order, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Order>>();

            response.Data = _orderRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<Order>> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var response = new BaseResponse<Order>();

            response.Data = await _orderRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Order>> UpdateAsync(long id, OrderCreationDTO entity)
        {
            var response = new BaseResponse<Order>();

            var entityToUpdate = await _orderRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _orderRepository.Update(entityToUpdate);

            await _orderRepository.SaveChangesAsync();

            return response;
        }
    }
}
    
