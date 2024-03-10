using AutoMapper;
using PetUci.Models;
using PetUci.ViewModels;
using System.Runtime.CompilerServices;

namespace PetUci.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageFile.PhysicalPath));
            CreateMap<ProductViewModel, Product>();

            CreateMap<Pet, PetViewModel>();
            CreateMap<PetViewModel, Pet>();

            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolObj.Id))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.RolObj.NombreRol));
            CreateMap<UserViewModel, User>();


            CreateMap<Rol, RolViewModel>();
            CreateMap<RolViewModel, Rol>();

            CreateMap<Vaccine, VaccineViewModel>();
            CreateMap<VaccineViewModel, Vaccine>();

            CreateMap<Disease, DiseaseViewModel>();
            CreateMap<DiseaseViewModel, Disease>();

            CreateMap<Treatment, TreatmentViewModel>()
            .ForMember(dest => dest.IdDisease, opt => opt.MapFrom(src => src.Disease.Id))
            .ForMember(dest => dest.Disease, opt => opt.MapFrom(src => src.Disease.Name));
            CreateMap<TreatmentViewModel, Treatment>();

            CreateMap<Forum, ForumViewModel>()
            .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.User.Id));
            CreateMap<ForumViewModel, Forum>();

            CreateMap<ImageFiles, ImageFilesViewModel>()
             .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
             .ForMember(dest=> dest.PetId, opt => opt.MapFrom(src=>src.Pet.Id));
            CreateMap<ImageFilesViewModel, ImageFiles>();

        }
    }
}
