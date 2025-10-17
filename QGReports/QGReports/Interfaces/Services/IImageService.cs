using QGReports.Domain.Dtos.ImageDtos;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IImageService : IAbstractService<GetImageDto, CreateImageDto, UpdateImageDto>
{
}
