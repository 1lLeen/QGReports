using QGReports.Domain.Dtos.EquipmentDtos;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IEquipmentService : IAbstractService<GetEquipmentDto, CreateEquipmentDto, UpdateEquipmentDto>
{
}
