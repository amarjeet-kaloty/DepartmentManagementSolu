using Application.DTOs.DepartmentDTOs;
using Application.DTOs.ExternalEmployeeDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, ReadDepartmentDTO>().ReverseMap();

            CreateMap<CreateDepartmentDTO, Department>().ReverseMap();

            CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();

            CreateMap<EmployeeExternalData, EmployeeReadDTO>().ReverseMap();
        }
    }
}
