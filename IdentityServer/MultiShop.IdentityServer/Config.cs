using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") {Scopes = { "CatalogFullPermission", "CatalogReadPermission" }},
            new ApiResource("ResourceDiscount") {Scopes = { "DiscountFullPermission"}},
            new ApiResource("ResourceOrder") {Scopes = { "OrderFullPermission"}},
            new ApiResource("ResourceCargo") {Scopes = { "CargoFullPermission"}},
            new ApiResource("ResourceBasket") {Scopes = { "BasketFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access for Catalog API"),
            new ApiScope("CatalogReadPermission", "Read access for Catalog API"),
            new ApiScope("DiscountFullPermission", "Full access for Discount API"),
            new ApiScope("OrderFullPermission", "Full access for Order API"),
            new ApiScope("CargoFullPermission", "Full access for Cargo API"),
            new ApiScope("BasketFullPermission", "Full access for Basket API"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };
    public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "DiscountFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },

            //Admin 
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                AccessTokenLifetime = 600
            }
        };
}
