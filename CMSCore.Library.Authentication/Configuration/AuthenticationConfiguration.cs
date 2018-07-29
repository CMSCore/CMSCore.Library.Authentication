namespace CMSCore.Library.Authentication.Configuration
{
    using Microsoft.Extensions.Configuration;

    /// <inheritdoc />
    /// <summary>
    /// Policies format: "read:messages"
    /// Domain format: "https://" + domain +  "/"
    /// 
    /// <example>
    /// "authentication": {
    ///     "ApiIdentifier": "identifier",
    ///     "Domain": "https://domain.eu.auth0.com/
    ///     "Policies": [
    ///         "read:messages",
    ///         "write:messages"
    ///     ]
    /// </example>
    /// 
    /// </summary>
    public class AuthenticationConfiguration : IAuthenticationConfiguration
    {
        public AuthenticationConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("Authentication").Bind(this);
        }

        public string ApiIdentifier { get; set; }
        public string Domain { get; set; }
        public string [ ] Policies { get; set; }
    }
}