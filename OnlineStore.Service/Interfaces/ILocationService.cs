using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Service.DTOs.LocationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface ILocationService
    {
        Task<BaseResponse<Location>> CreateAsync(LocationCreationDTO entity);

        Task<BaseResponse<Location>> UpdateAsync(long id, LocationCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Location, bool>> expression);

        Task<BaseResponse<Location>> GetAsync(Expression<Func<Location, bool>> expression);

        Task<BaseResponse<IEnumerable<Location>>> GetAllAsync(Expression<Func<Location, bool>> expression = null);
    }
}
