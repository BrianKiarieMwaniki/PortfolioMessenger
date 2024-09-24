using PortfolioMessenger.Api.Services;

namespace PortfolioMessenger.Api.Endpoints;

public static class SendEmailEndpoints
{
    public static RouteGroupBuilder MapSendEmailEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/sendemail")
                            .WithOpenApi();



        group.MapPost("/", async (ISendEmailService sendEmailService, Dictionary<string, string> templateParameters) =>
        {
            var response = await sendEmailService.SendEmail(templateParameters);

            if(response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                return Results.Ok(content);
            }
            else{
                var errorContent = await response.Content.ReadAsStringAsync();

                return Results.BadRequest(errorContent);
            }

        });


        return group;
    }

    
}