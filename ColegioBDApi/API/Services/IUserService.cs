using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services
{
    public interface IUserService
    {
        
        Task<string> RegisterAsync (RegisterDto model);
         Task<DatosUserDto> GetTokenAsync (LoginDto model);
        Task<DatosUserDto> RefreshTokenAsync (string refreshToken);
         Task<string> AddRoleAsync (AddRoleDto model);
        
    }
}