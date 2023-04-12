namespace SignalR_Sample.WebApi.Configurations
{
    public class JwtSettings
    {
        public JwtSettings(int _jwtLifespan, string _jwtSecretKey)
        {
            this.JWTLifespan = _jwtLifespan;
            this.JWTSecretKey = _jwtSecretKey;
        }
        public JwtSettings() { }
        public string JWTSecretKey { get; init; }
        public int JWTLifespan { get; init; }
    }
}
