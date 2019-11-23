// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Gmcs.IdentityServer {
    public static class Config {
        public static IEnumerable<IdentityResource> GetIdentityResources() {
            return new IdentityResource[]{new IdentityResources.OpenId()};
        }


        // / <summary>
        // / Provides a List of APIs protected by IDS
        // / </summary>
        // / <returns>Return a List of ApiResource</returns>
        public static IEnumerable<ApiResource> GetApis() {
            return new List<ApiResource> {
                new ApiResource("spApi", "SharePoint APIs"),
                new ApiResource("hrApi", "HR APIs")
            };
        }

        // / <summary>
        // / Provide  a List of Client authorized and their APIs
        // / </summary>
        // / <returns>Return a List of Client</returns>
        public static IEnumerable<Client> GetClients() {
            return new List<Client> {
                new Client {
                    ClientId = "uiClient",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {
                        "spApi",
                        "hrApi"
                    }
                }
            };
        }
    }
}
