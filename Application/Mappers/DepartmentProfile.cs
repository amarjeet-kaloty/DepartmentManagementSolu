using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, ReadDepartmentDTO>().ReverseMap();

            CreateMap<CreateDepartmentDTO, Department>().ReverseMap();

            CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();
        }
    }
}
