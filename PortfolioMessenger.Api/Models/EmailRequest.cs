using System.Text.Json.Serialization;

namespace PortfolioMessenger.Api.Models;

public class EmailRequest
{
    [JsonPropertyName("service_id")]
    public string? ServiceId {get;set;}
    [JsonPropertyName("template_id")]
    public string? TemplateId {get;set;}
    [JsonPropertyName("user_id")]
    public string? UserId {get;set;}
    [JsonPropertyName("template_params")]
    public Dictionary<string, string>? TemplateParameters {get;set;}
    [JsonPropertyName("accessToken")]
    public string? AccessToken {get;set;}
}