using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// file requisite namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//user defined
using Catalog.Infrastructure;

namespace Catalog.API.Extensions
{
    public static class DatabaseExtension
    {

        public static IServiceCollection AddCatalogContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<CatalogContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(
                        "Server=localhost, 1433; Initial Catalog=Store; User Id=<SA_USER>;Password=<PASSWORD>",
                        serverOptions =>
                        {
                            serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                        }
                    );
                });
        }

    }
}
