namespace BugTracker.RestServices
{
    using System;

    using BugTracker.Data;
    using BugTracker.RestServices.Providers;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    using Owin;

    public partial class Startup
    {
        public const string TokenEndpointPath = "/api/token";

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(BugTrackerDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow. Do it only once!
            if (OAuthOptions == null)
            {
                PublicClientId = "self";
                OAuthOptions = new OAuthAuthorizationServerOptions
                {
                    TokenEndpointPath = new PathString(TokenEndpointPath),
                    Provider = new ApplicationOAuthProvider(PublicClientId),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                    AllowInsecureHttp = true
                };
            }

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
