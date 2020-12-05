using System;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("autenticated")]
        public bool autenticated { get; set; }
        [JsonProperty("create")]
        public DateTime create { get; set; }
        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }
        [JsonProperty("token")]
        public string token { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }
}