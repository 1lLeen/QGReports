using AutoMapper;
using QGReports.Domain.Dtos.EquipmentDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Interfaces.Services;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class EquipmentService : AbstractService<IEquipmentRepos, EquipmentModel, GetEquipmentDto, CreateEquipmentDto, UpdateEquipmentDto>,
    IEquipmentService
{
    public EquipmentService(IMapper mapper, IEquipmentRepos repository) : base(mapper, repository)
    {
    }
}
