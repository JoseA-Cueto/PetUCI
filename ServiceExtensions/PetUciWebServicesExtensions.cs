using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Repositories;
using PetUci.Services;

namespace PetUci.ServiceExtensions
{
    public static class PetUciWebServicesExtensions 
    {
        public static void AddPetUciWebServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPetRepositories, PetRepositories>();
            services.AddScoped<IPetService, PetService>();
        }
    }
}
