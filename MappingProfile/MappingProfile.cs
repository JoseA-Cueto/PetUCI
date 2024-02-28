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

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Rol, RolViewModel>();
            CreateMap<RolViewModel, Rol>();

            CreateMap<Vaccine, VaccineViewModel>();
            CreateMap<VaccineViewModel, Vaccine>();

            CreateMap<Disease, DiseaseViewModel>();
            CreateMap<DiseaseViewModel, Disease>();

            CreateMap<Treatment, TreatmentViewModel>();
            CreateMap<TreatmentViewModel, Treatment>();

            CreateMap<Forum, ForumViewModel>();
            CreateMap<ForumViewModel, Forum>();

            CreateMap<ImageFiles, ImageFilesViewModel>();
            CreateMap<ImageFilesViewModel, ImageFiles>();

        }
    }
}
