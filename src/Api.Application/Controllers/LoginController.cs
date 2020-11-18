using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Interfaces.Services;
using Api.Domain.Dtos;
using Api.Domain.Entities;
namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
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
                UserEntity result = await service.FindByLogin(loginDto.Email);
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