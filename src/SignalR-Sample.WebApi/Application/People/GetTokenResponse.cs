namespace SignalR_Sample.WebApi.Application.People
{
    public record GetTokenResponse(
        long PersonId,
        string UserName,
        string Token);
}
