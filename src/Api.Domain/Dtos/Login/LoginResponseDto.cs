using System;
namespace Api.Domain.Dtos.Login
{
    public class LoginResponseDto
    {
        public bool Authenticated { get; set; }
        public DateTime Create { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string Message { get; set; }
    }
}