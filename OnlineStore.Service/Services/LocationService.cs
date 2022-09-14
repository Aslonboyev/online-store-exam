using AutoMapper;
using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Mappers;
using System.Linq.Expressions;

namespace OnlineStore.Service.Services
{
    public class LocationService : ILocationService
    {

        readonly ILocationRepository _locationRepository;
        readonly IMapper _mapper;

        public LocationService()
        {
            _locationRepository = new LocationRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<BaseResponse<Location>> CreateAsync(LocationCreationDTO entity)
        {
            var response = new BaseResponse<Location>();

            if (await _locationRepository.GetAsync(p => p.Region == entity.Region || p.Name == entity.Name) is not null)
            {
                response.Error = new ErrorResponse(400, "Region already exists");
                return response;
            }

            var location = _mapper.Map<Location>(entity);

            response.Data = await _locationRepository.CreateAsync(location);

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Location, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var entity = await _locationRepository.GetAsync(expression);

            if (entity is null || entity.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(400, "Client is not exists");
                response.Data = false;

                return response;
            }

            entity.Delete();

            await _locationRepository.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Location>>> GetAllAsync(Expression<Func<Location, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Location>>();

            response.Data = _locationRepository.GetAll(expression).Where(p => p.ItemState != ItemState.Deleted);

            return response;
        }

        public async Task<BaseResponse<Location>> GetAsync(Expression<Func<Location, bool>> expression)
        {

            var response = new BaseResponse<Location>();

            response.Data = await _locationRepository.GetAsync(expression);

            if (response.Data is null || response.Data.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found");

                return response;
            }

            return response;
        }

        public async Task<BaseResponse<Location>> UpdateAsync(long id, LocationCreationDTO entity)
        {

            var response = new BaseResponse<Location>();

            var entityToUpdate = await _locationRepository.GetAsync(entity => entity.Id == id);

            if (entityToUpdate is null || entityToUpdate.ItemState == ItemState.Deleted)
            {
                response.Error = new ErrorResponse(404, "Client is not found for updating");

                return response;
            }

            entityToUpdate = _mapper.Map(entity, entityToUpdate);

            entityToUpdate.Update();

            _locationRepository.Update(entityToUpdate);

            await _locationRepository.SaveChangesAsync();

            return response;
        }
    }
}
