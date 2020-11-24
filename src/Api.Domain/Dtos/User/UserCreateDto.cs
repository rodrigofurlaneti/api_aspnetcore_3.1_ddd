using System;
namespace Api.Domain.Dtos
{
    public class UserCreateDto
    {
        public Guid Id{ get; set;}
        public string Name{ get; set;}
        public string Email{ get; set;}
    }
}