using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEncryptionService, EncryptionService>();

            services.AddScoped<IProductRepositories, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IImageFileRepository, ImageFileRepository>();
            services.AddScoped<IImageFileService, ImageFileService>();


            services.AddScoped<IRolRepository,RolRepository >();
            services.AddScoped<IRolService,RolService >();

            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<ITreatmentService, TreatmentService>();

            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IForumService, ForumService>();

            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IVaccineService, VaccineService>();



        }
    }
}
