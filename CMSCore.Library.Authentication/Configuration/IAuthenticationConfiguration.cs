namespace CMSCore.Library.Authentication.Configuration
{

     /// <summary>
    /// Policies format: "read:messages"
    /// Domain format: "https://" + domain +  "/"
    /// 
    ///<code>
    /// "authentication": {
    ///     "ApiIdentifier": "identifier",
    ///     "Domain": "https://domain.eu.auth0.com/
    ///     "Policies": [
    ///         "read:messages",
    ///         "write:messages"
    ///     ]
    /// </code>
    /// 
    /// </summary>
    public interface IAuthenticationConfiguration
    {
        string ApiIdentifier { get; set; }
        string Domain { get; set; }
        string[] Policies { get; set; }
    }
}