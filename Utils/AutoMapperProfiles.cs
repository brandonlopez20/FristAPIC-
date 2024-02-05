
using AutoMapper;
using Relaciones.DTOS;
using Relaciones.Models;

namespace Relaciones.Utils

{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RelacionUnoDTO,RelacionUno>();

            CreateMap<ProductoCreateDTO, Producto>();
        }
    }
}
