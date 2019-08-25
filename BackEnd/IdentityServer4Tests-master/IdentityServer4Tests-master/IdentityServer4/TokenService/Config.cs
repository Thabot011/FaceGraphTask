// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("FaceGraphProject")
                {
                    ApiSecrets = {new Secret("secret".Sha256())}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "angular.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "FaceGraphProject" },
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "demo",
                    Password = "demo",
                   Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Test User"),
                    new Claim(ClaimTypes.Email, "email@mail.com"),
                }
                }
            };
        }
    }
}