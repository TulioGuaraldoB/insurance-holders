using Microsoft.Extensions.DependencyInjection;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Infra.Repositories;
using InsuranceHolders.Domain.Queries;
using InsuranceHolders.Domain.Commands;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Application.DependencyInjection
{
    public class SetupDependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IHolderQueriesRepository, HolderQueriesRepository>();
            services.AddScoped<IHolderCommandsRepository, HolderCommandsRepository>();
            services.AddScoped<IHolderQueries, HolderQueries>();
            services.AddScoped<IHolderCommands, HolderCommands>();
        }
    }
}