using AutoMapper;
using Demo.Core.Models;
using Demo.ViewModels;

namespace Demo
{
    public class AutoMapper : Profile {

        public AutoMapper() { 
        
            CreateMap<ProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, ProductViewModel>();
        }
    }
}