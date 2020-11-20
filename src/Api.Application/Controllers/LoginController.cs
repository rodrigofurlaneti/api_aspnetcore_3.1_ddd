using System.Net;
using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Interfaces.Services;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Api.Domain.Dtos;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _loginService { get; set; }
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            var dataClientRequest = Dns.GetHostEntry(Dns.GetHostName());
            string getHostName = dataClientRequest.HostName.ToString();
            string getIPV6 = dataClientRequest.AddressList[0].ToString();
            string getIPV4 = dataClientRequest.AddressList[4].ToString();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Erro 400 Bad Request
            }
            if(loginDto == null)
            {
                return BadRequest(); // Erro 400 Bad Request
            }
            try
            {
                UserEntity result = await service.FindByLogin(loginDto.Email, getHostName, getIPV6, getIPV4);
                if(result != null)
                {
                    return Ok(result); // Req 200
                }
                else
                {
                    return NotFound(); // Error 404 Not found
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); //Erro 500
            }
        }
    }
}