namespace BlogPost.Infrastructure.ConfigOptions;

public class JwtConfigOptions
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}