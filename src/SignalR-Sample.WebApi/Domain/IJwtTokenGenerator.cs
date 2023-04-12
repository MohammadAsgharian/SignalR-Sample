namespace SignalR_Sample.WebApi.Domain
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(long PersonId, string UserName);
        string GenerateRefreshToken();
    }
}
