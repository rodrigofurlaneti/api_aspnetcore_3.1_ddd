using System;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        private ILogRepository _logRepository;
        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration{ get; }
        public LoginService(IUserRepository userRepository,
                            ILogRepository logRepository,
                            SigningConfigurations signingConfigurations,
                            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _logRepository = logRepository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }
        public async Task<UserEntity> FindByLogin(string email, string hostName, string ipv6, string ipv4)
        {
            UserEntity baseUser = new UserEntity();
            if(email != null && !string.IsNullOrWhiteSpace(email))
            {
                baseUser = await _userRepository.FindByLogin(email);
                if(baseUser == null)
                {
                    UserEntity baseUserResp = new UserEntity();
                    baseUserResp.Email = email;
                    baseUserResp.Authenticated = false;
                    baseUserResp.Message = "Falha ao atenticar, não existe este e-mail cadastrado na base!";
                    await _logRepository.CreateLogAsync(baseUserResp, hostName, ipv6, ipv4);
                    return baseUserResp;
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new []
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //id do token
                            new Claim(JwtRegisteredClaimNames.UniqueName, email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds"))); //id do token
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    UserEntity baseUserOk = new UserEntity();
                    baseUserOk = SuccessObject(baseUser.Id, baseUser.Name, createDate, expirationDate, token, email);
                    await _logRepository.CreateLogAsync(baseUserOk, hostName, ipv6, ipv4);
                    return baseUserOk;
                }
            }
            else
            {
                return null;
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
        private UserEntity SuccessObject(Guid id, string name, DateTime createDate, DateTime expirationDate, string token, string email)
        {
            UserEntity baseUserOk = new UserEntity();
            baseUserOk.Id = id;
            baseUserOk.Name = name;
            baseUserOk.Authenticated = true;
            baseUserOk.CreateAt = createDate;
            baseUserOk.UpdateAt = DateTime.Now;
            baseUserOk.Expiration = expirationDate;
            baseUserOk.Token = token;
            baseUserOk.Email = email;
            baseUserOk.Message = "Usuário logado com sucesso";
            return baseUserOk;
        }
    }
}