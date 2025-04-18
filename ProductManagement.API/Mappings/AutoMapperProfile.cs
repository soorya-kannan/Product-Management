using AutoMapper;
using ProductManagement.API.DTO;
using ProductManagement.API.Models;

namespace ProductManagement.API.Mappings
{
    public class AutoMapperProfile:Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

        }


    }
}
