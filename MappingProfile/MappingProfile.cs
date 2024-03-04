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
            .ForMember(dest => dest.rolId, opt => opt.MapFrom(src => src.rolObj.id))
            .ForMember(dest => dest.rol, opt => opt.MapFrom(src => src.rolObj.nombreRol));
            CreateMap<UserViewModel, User>();


            CreateMap<Rol, RolViewModel>();
            CreateMap<RolViewModel, Rol>();

            CreateMap<Vaccine, VaccineViewModel>();
            CreateMap<VaccineViewModel, Vaccine>();

            CreateMap<Disease, DiseaseViewModel>();
            CreateMap<DiseaseViewModel, Disease>();

            CreateMap<Treatment, TreatmentViewModel>()
            .ForMember(dest => dest.idDisease, opt => opt.MapFrom(src => src.disease.Id))
            .ForMember(dest => dest.disease, opt => opt.MapFrom(src => src.disease.name));
            CreateMap<TreatmentViewModel, Treatment>();

            CreateMap<Forum, ForumViewModel>()
            .ForMember(dest => dest.idUser, opt => opt.MapFrom(src => src.user.id));
            CreateMap<ForumViewModel, Forum>();

            CreateMap<ImageFiles, ImageFilesViewModel>()
             .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.id))
             .ForMember(dest=> dest.PetId, opt => opt.MapFrom(src=>src.Pet.id));
            CreateMap<ImageFilesViewModel, ImageFiles>();

        }
    }
}
