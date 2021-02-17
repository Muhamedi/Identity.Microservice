using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Microservice
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "muki",
                    Password = "muki",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Mukesh Murugan"),
                        new Claim(JwtClaimTypes.GivenName, "Mukesh"),
                        new Claim(JwtClaimTypes.FamilyName, "Murugan"),
                        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                    }
                }
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                new IdentityResource[]
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "books",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret") },
                    AllowedScopes = { "myApi.read" }
                },
            };
    }
}
