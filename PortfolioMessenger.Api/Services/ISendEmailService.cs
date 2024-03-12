namespace PortfolioMessenger.Api.Services;

public interface ISendEmailService
{
    Task<HttpResponseMessage> SendEmail(Dictionary<string, string>? templateParameters);
}