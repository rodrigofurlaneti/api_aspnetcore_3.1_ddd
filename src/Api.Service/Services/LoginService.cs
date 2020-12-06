using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Api.Domain.Dtos.Login;
using Api.Domain.Login.Dtos;
using System.Security.Principal;
namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration{ get; }
        public LoginService(IUserRepository userRepository,
                            SigningConfigurations signingConfigurations,
                            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }
        public LoginResponseDto FindByLogin(string email)
        {
            UserEntity baseUser = new UserEntity();
            LoginResponseDto loginResponseDto = new LoginResponseDto();
            if (email != null && !string.IsNullOrWhiteSpace(email))
            {
                baseUser = _userRepository.FindByLogin(email);
                if (baseUser == null)
                {
                    loginResponseDto.Authenticated = false;
                    loginResponseDto.Message = "Falha ao autenticar";
                    return loginResponseDto;
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, email),
                        }
                    );
                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    loginResponseDto = SuccessObject(baseUser.Name, createDate, expirationDate, token, baseUser.Name);                     
                    return loginResponseDto;
                }
            }
            else
            {
                loginResponseDto.Authenticated = false;
                loginResponseDto.Message = "Falha ao autenticar";
                return loginResponseDto;
            }
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });
            string token = handler.WriteToken(securityToken);
            return token; 
        }
        private LoginResponseDto SuccessObject(string name, DateTime createDate, DateTime expirationDate, string token, string email)
        {
            LoginResponseDto loginResponseDtoSuccess = new LoginResponseDto();
            loginResponseDtoSuccess.Name = name;
            loginResponseDtoSuccess.Authenticated = true;
            loginResponseDtoSuccess.CreateAt = createDate;
            loginResponseDtoSuccess.Expiration = expirationDate;
            loginResponseDtoSuccess.Token = token;
            loginResponseDtoSuccess.Email = email;
            loginResponseDtoSuccess.Message = "Usuário logado com sucesso";
            return loginResponseDtoSuccess;
        }
        public async Task<LoginResponseDto> FindByLoginAsync(string email)
        {
            UserEntity baseUser = new UserEntity();
            LoginResponseDto loginResponseDto = new LoginResponseDto();
            if (email != null && !string.IsNullOrWhiteSpace(email))
            {
                baseUser = await _userRepository.FindByLoginAsync(email);
                if (baseUser == null)
                {
                    loginResponseDto.Authenticated = false;
                    loginResponseDto.Message = "Falha ao autenticar";
                    return loginResponseDto;
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, email),
                        }
                    );
                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(baseUser.Name, createDate, expirationDate, token, baseUser.Name);                     
                }
            }
            else
            {
                loginResponseDto.Authenticated = false;
                loginResponseDto.Message = "Falha ao autenticar";
                return loginResponseDto;
            }
        }
    }
}