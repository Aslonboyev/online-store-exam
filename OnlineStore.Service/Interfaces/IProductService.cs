using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<Product>> CreateAsync(ProductCreationDTO entity);

        Task<BaseResponse<Product>> UpdateAsync(long id, ProductCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression);

        Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression);

        Task<BaseResponse<IEnumerable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
    }
}
