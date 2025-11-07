using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(), 
                
                new IdentityResources.Profile(), 
                
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission", "Katalog API için tam erişim"),
                new ApiScope("CatalogReadPermission", "Katalog API için sadece okuma erişimi"),

                new ApiScope("DiscountFullPermission", "İndirim API için tam erişim"),

                new ApiScope("OrderFullPermission", "Sipariş API için tam erişim"),

                new ApiScope("CargoFullPermission" , "Kargo API icin tam erisim"),

                new ApiScope(IdentityServerConstants.LocalApi.ScopeName, "IdentityServer API erişimi")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ResourceCatalog")
                {
                    Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
                },

                new ApiResource("ResourceDiscount")
                {
                    Scopes = { "DiscountFullPermission" }
                },

                new ApiResource("ResourceOrder")
                {
                    Scopes = { "OrderFullPermission" }
                },

                new ApiResource("ResourceCargo")
                {
                    Scopes = {"CargoFullPermission"}
                },

                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                {
                    Scopes = { IdentityServerConstants.LocalApi.ScopeName }
                }
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "MultiShopVisitorId",
                    ClientName = "Multi Shop Visitor User",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, 
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes = { "DiscountFullPermission" }
                },

                new Client
                {
                    ClientId = "MultiShopManagerId",
                    ClientName = "Multi Shop Manager User",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, 
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
                },

                new Client
                {
                    ClientId = "MultiShopAdminId",
                    ClientName = "Multi Shop Admin User (Machine)",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes =
                    {
                        "CatalogFullPermission",
                        "CatalogReadPermission",
                        "DiscountFullPermission",
                        "OrderFullPermission",
                        "CargoFullPermission",
                        IdentityServerConstants.LocalApi.ScopeName, 
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    AccessTokenLifetime = 3600
                },

            };
    }
}
