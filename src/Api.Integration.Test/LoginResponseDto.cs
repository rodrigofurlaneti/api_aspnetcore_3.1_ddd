using System;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("autenticated")]
        public bool Autenticated { get; set; }
        [JsonProperty("createAt")]
        public DateTime CreateAt { get; set; }
        [JsonProperty("updateAt")]
        public DateTime UpdateAt { get; set; }
 
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}