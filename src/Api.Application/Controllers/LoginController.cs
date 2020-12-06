using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Interfaces.Services;
using Api.Domain.Login.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
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
                LoginResponseDto result = await service.FindByLoginAsync(loginDto.Email);
                if(result != null)
                {
                    return result; // Req 200
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