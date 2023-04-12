namespace SignalR_Sample.WebApi.Configurations
{
    public class JwtSettings
    {
        public JwtSettings(int _jwtLifespan, string _jwtSecretKey, int _refreshTokenTimeout)
        {
            this.JWTLifespan = _jwtLifespan;
            this.JWTSecretKey = _jwtSecretKey;
            this.RefreshTokenTimeout = _refreshTokenTimeout;
        }
        public JwtSettings() { }
        public string JWTSecretKey { get; init; }
        public int JWTLifespan { get; init; }
        public int RefreshTokenTimeout { get; init; }
    }
}
