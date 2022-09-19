using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.DTOs.UserDTOs;

namespace OnlineStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        public User Create(UserCreationDTO creationDTO)
        {
            
        }
    }
}
