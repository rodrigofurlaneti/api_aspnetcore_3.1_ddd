using System;
namespace Api.Domain.Dtos.Login
{
    public class LoginResponseDto
    {
        public bool Authenticated { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}