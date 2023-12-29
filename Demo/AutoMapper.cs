using AutoMapper;
using Demo.Core.Models;
using Demo.Core.ViewModels;
using Demo.ViewModels;

namespace Demo
{
    public class AutoMapper : Profile {

        public AutoMapper() { 
        
            CreateMap<ProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, ProductViewModel>();

            CreateMap<UserViewModel, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, UserViewModel>();

            CreateMap<ApplicationUserDTO, UserWithRolesViewModel>();

            CreateMap<ApplicationUserDTO, UserWithRolesViewModel>()
           .ForMember(dest => dest.UserToRoles, opt => opt.MapFrom(src => src.ApplicationUserToRoles));

            CreateMap<ApplicationUserToRoleDTO, UserToRoleViewModel>();
            CreateMap<RoleDTO, RoleViewModel>();

        }
    }
}