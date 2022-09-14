using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Contacts;
using OnlineStore.Service.DTOs.ContactDTOs;
using System.Linq.Expressions;

namespace OnlineStore.Service.Interfaces
{
    public interface IContactService
    {

        Task<BaseResponse<Contact>> CreateAsync(ContactCreationDTO entity);

        Task<BaseResponse<Contact>> UpdateAsync(long id, ContactCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Contact, bool>> expression);

        Task<BaseResponse<Contact>> GetAsync(Expression<Func<Contact, bool>> expression);

        Task<BaseResponse<IEnumerable<Contact>>> GetAllAsync(Expression<Func<Contact, bool>> expression = null);
    }
}
