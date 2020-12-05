namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("autenticated")]
        public bool autenticated { get; set; }
        [JsonProperty("create")]
        public DateTime create { get; set; }
        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }
        [JsonProperty("accessToken")]
        public string accessToken { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }
}