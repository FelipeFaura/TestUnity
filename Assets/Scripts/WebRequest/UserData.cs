using Newtonsoft.Json;

[System.Serializable]
public class IUserData
{
    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("mision")]
    public string mission { get; set; }

    [JsonProperty("user")]
    public string user { get; set; }
}