using AutoMapper;
using QGReports.Domain.Dtos.EquipmentDtos;
using QGReports.Domain.Dtos.ReportDtos;
using QGReports.Domain.Dtos.UsersDtos;
using QGReports.Domain.Models;

namespace QGReports.Application.Services.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserModel, GetUserDto>().ReverseMap();
        CreateMap<UserModel, CreateUserDto>().ReverseMap();
        CreateMap<UserModel, UpdateUserDto>().ReverseMap();
        CreateMap<EquipmentModel, GetEquipmentDto>().ReverseMap();
        CreateMap<EquipmentModel, CreateEquipmentDto>().ReverseMap();
        CreateMap<EquipmentModel, UpdateEquipmentDto>().ReverseMap();
        CreateMap<ReportModel, GetReportDto>().ReverseMap();
        CreateMap<ReportModel, CreateReportDto>().ReverseMap();
        CreateMap<ReportModel, UpdateReportDto>().ReverseMap();

        ApplyMappingsFromAssembly(typeof(MappingProfile).Assembly);
    } 
    private void ApplyMappingsFromAssembly(System.Reflection.Assembly assembly)
    {
        var types = assembly.GetExportedTypes();
        var maps = (from type in types
                    from iface in type.GetInterfaces()
                    where iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(MappingProfile)
                    select new
                    {
                        Source = iface.GetGenericArguments()[0],
                        Destination = type
                    }).ToList();
        foreach (var map in maps)
        {
            CreateMap(map.Source, map.Destination);
        }
    }
}
