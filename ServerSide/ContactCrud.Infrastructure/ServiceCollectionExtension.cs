using ContactCrud.Application.Interfaces;
using ContactCrud.Infrastructure.Repository;
using ContactCrud.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContactCrud.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
        }
    }
}
