﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CasgemMicroservices.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources=>new ApiResource[]
        {
            new ApiResource("resource_catalog") {Scopes={"catalog_fullpermission"} },
            new ApiResource("resource_photostock"){Scopes={ "photostock_fullpermission" } },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Ürün Listesi için tam erişim"),
                 new ApiScope("photostock_fullpermission","Fotoğraf işlemleri  için tam erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client

                //Yetkisiz erişim sadece anasayfayı görüyo
                new Client
                {
                    ClientId = "Casgem1Client",
                    ClientName = "Casgem Client Name",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) }, 
                    AllowedScopes = { "catalog_fullpermission", "photostock_fullpermission",IdentityServerConstants.LocalApi.ScopeName }

                },

                new Client
                {
                    ClientId = "Casgem2Client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    ClientName = "Casgem2 Client Name", 
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //Kendi şifresini belirlesin
                    AllowOfflineAccess = true, //internet olmadan da kullanılsın token
                    AllowedScopes = { "catalog_fullpermission", "basket_fullpermission", IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile },AccessTokenLifetime=3600
                    //IdentityServerConstants token içeriğini mail ıd ve şifre bilgilerini gönderecek asp net user tablo bilgilerini alacak 
                },
            };
    }
}