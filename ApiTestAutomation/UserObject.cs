using Newtonsoft.Json;

public class ApiResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public UserProfile Data { get; set; }
}

public class UserProfile
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}
