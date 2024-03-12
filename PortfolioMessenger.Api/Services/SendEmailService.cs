using Microsoft.Extensions.Options;
using PortfolioMessenger.Api.Config;
using PortfolioMessenger.Api.Models;

namespace PortfolioMessenger.Api.Services;

public class SendEmailService : ISendEmailService
{
    private readonly HttpClient _httpClient;
    private readonly EmailApiOptions _emailApiOptions;
    private readonly EmailApiAccessOptions _emailApiAccessOptions;
    public SendEmailService(HttpClient httpClient, 
    IOptions<EmailApiOptions> emailApiOptions, IOptions<EmailApiAccessOptions> emailApiAccessOptions)
    {
        _httpClient = httpClient;
        _emailApiOptions = emailApiOptions.Value;
        _emailApiAccessOptions = emailApiAccessOptions.Value;
    }

    public async Task<HttpResponseMessage> SendEmail(Dictionary<string, string>? templateParameters)
    {
        var emailRequest = new EmailRequest
        {
            ServiceId = _emailApiAccessOptions.ServiceId,
            TemplateId = _emailApiAccessOptions.TemplateId,
            UserId = _emailApiAccessOptions.UserId,
            TemplateParameters = templateParameters,
            AccessToken = _emailApiAccessOptions.AccessToken
        };

        var response = await _httpClient.PostAsJsonAsync<EmailRequest>(_emailApiOptions.Endpoint, emailRequest);

        return response;
    }
}