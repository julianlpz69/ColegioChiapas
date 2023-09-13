using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using API.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;  

        public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<User> passwordHasher)
        {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }







        

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var usuario = new User 
            {
                UserEmail = registerDto.UserEmail,
                UserName = registerDto.UserName
            };
            
            usuario.UserPassword = _passwordHasher.HashPassword(usuario, registerDto.UserPassword);
            var usuarioExiste = _unitOfWork.Users
                                                  .Find(u => u.UserName.ToLower() == registerDto.UserName.ToLower())
                                                  .FirstOrDefault();
            
             if(usuarioExiste == null)
            {
                try
                {
                    _unitOfWork.Users.Add(usuario);
                    await _unitOfWork.SaveAsync();

                    return $"El usuario {registerDto.UserName} ha sido creado exitosamente ";

                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }
            }
            else
            {
                return $"El usuario {registerDto.UserName} ya se encuentra registrado";
            }

        } 








        public async Task<string> AddRoleAsync (AddRoleDto model)
        {
            var usuario = await _unitOfWork.Users.GetByUsernameAsync(model.UserName);

            if(usuario == null)
            {
                return $"No existe usuario registrado con la cuenta olvido algun caracter?{model.UserName}.";
            }

            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.UserPassword, model.UserPassword);

            if(resultado == PasswordVerificationResult.Success)
            {
                var rolExiste = _unitOfWork.Roles
                                                .Find(u => u.NombreRol.ToLower() == model.Rol.ToLower()) 
                                                .FirstOrDefault();   

                if(rolExiste != null)
                {
                    var usuarioTieneRol = usuario.Rols
                                                    .Any(u => u.Id == rolExiste.Id);

                    if (usuarioTieneRol == false)
                    {
                        usuario.Rols.Add(rolExiste);
                        _unitOfWork.Users.Update(usuario);
                        await _unitOfWork.SaveAsync();
                    }

                    return $"Rol {model.Rol} agregado a la cuenta {model.UserName} de forma exitosa";
                }

                return $"Rol {model.Rol} no encontrado";
            }
            return $"Credenciales incorrectas para el usuario {usuario.UserName}";
        }



    private static readonly ConcurrentDictionary<string, Guid> _refreshToken;

    private Guid GenerateRefreshToken(string Username)
    {
        Guid newRefreshToken = _refreshToken.AddOrUpdate(Username, u => Guid.NewGuid(), (u,o) => Guid.NewGuid());
        return newRefreshToken;
    }


        
        public async Task<DatosUserDto> GetTokenAsync(LoginDto model)
        {
            DatosUserDto datosUsuarioDto = new DatosUserDto();
            var usuario = await _unitOfWork.Users
                            .GetByUsernameAsync(model.UserName);

            if (usuario == null)
            {
                datosUsuarioDto.EstadoAutenticado = false;
                datosUsuarioDto.Mensaje = $"No existe ningun usuario con el username {model.UserName}.";
                return datosUsuarioDto;
            }

            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.UserPassword, model.UserPassword);
            if (result == PasswordVerificationResult.Success)
            {
                datosUsuarioDto.Mensaje = "OK";
                datosUsuarioDto.EstadoAutenticado = true;
                if (usuario != null)
                {
                    JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                    datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    datosUsuarioDto.UserName = usuario.UserName;
                    datosUsuarioDto.UserEmail = usuario.UserEmail;
                    datosUsuarioDto.Roles = usuario.Rols
                                                        .Select(p => p.NombreRol)
                                                        .ToList();

                    datosUsuarioDto.Expiry = DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes);

                    datosUsuarioDto.RefreshToken = GenerateRefreshToken(usuario.UserName).ToString("D");

                    return datosUsuarioDto;
                }
                else
                {
                    datosUsuarioDto.EstadoAutenticado = false;
                    datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.UserName}.";

                    return datosUsuarioDto;
                }
            }

            datosUsuarioDto.EstadoAutenticado = false;
            datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.UserName}.";

            return datosUsuarioDto;

    }




    public async Task<DatosUserDto> GetTokenAsync(AuthenticationTokenResultDto model)
    {
        if (!IsValid(model, out string UserName))
        {
            return null;
        }
        DatosUserDto datosUsuarioDto = new DatosUserDto();
        var user = await _unitOfWork.Users
                    .GetByUsernameAsync(UserName);

        if (user == null)
        {
            datosUsuarioDto.EstadoAutenticado = false;
            datosUsuarioDto.Mensaje = $"User does not exist with username {UserName}.";
            return datosUsuarioDto;
        }





            datosUsuarioDto.Mensaje = "OK";
            datosUsuarioDto.EstadoAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuarioDto.UserEmail = user.UserEmail;
            datosUsuarioDto.UserName = user.UserName;
            datosUsuarioDto.Roles = user.Rols
                                            .Select(u => u.NombreRol)
                                            .ToList();
            datosUsuarioDto.Expiry = DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes);

            datosUsuarioDto.RefreshToken = GenerateRefreshToken(user.UserName).ToString("D");
            return datosUsuarioDto;

    }


    private bool IsValid(AuthenticationTokenResultDto authResult, out string UserName)
    {
        UserName = string.Empty;

        ClaimsPrincipal principal = GetPrincipalfromExpiredToken(authResult.AccessTokoken);

        if (principal == null)
        {
            throw new UnauthorizedAccessException("No hay token de Acceso");
        }

        UserName = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(UserName))
        {
            throw new UnauthorizedAccessException("En UserName es nulo o esta vacio");
        }

        if (!Guid.TryParse(authResult.RefreshToken, out Guid givenRefreshToken))
        {
            throw new UnauthorizedAccessException("El Refresh Token esta mal Formado");
        }

        if (!_refreshToken.TryGetValue(UserName, out Guid currentRefreshToken))
        {
            throw new UnauthorizedAccessException("El refresh token no es valido en el sistema");
        }


        if (currentRefreshToken != givenRefreshToken)
        {
            throw new UnauthorizedAccessException("El refresh Token enviado es Invalido");
        }
        
        return true;

    }





    private ClaimsPrincipal GetPrincipalfromExpiredToken (string accessToken)
    {
        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidIssuer = _jwt.Issuer,
            ValidAudience = _jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key))
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        ClaimsPrincipal principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);

        if(securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals
        (SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCulture))
        {
            throw new UnauthorizedAccessException("El token es invalido"); 
        }

        return principal;
    }

    private JwtSecurityToken CreateJwtToken(User usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
        }

        var roles = usuario.Rols ;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.NombreRol));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", usuario.Id.ToString())
            }
        .Union(roleClaims);

        if (string.IsNullOrEmpty(_jwt.Key) || string.IsNullOrEmpty(_jwt.Issuer) || string.IsNullOrEmpty(_jwt.Audience))
        {
            throw new ArgumentNullException("La configuración del JWT es nula o vacía.");
        }

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        var JwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

        return JwtSecurityToken;
    }


    }
}