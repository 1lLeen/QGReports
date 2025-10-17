using AutoMapper;
using QGReports.Domain.Dtos.ImageDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Interfaces.Services;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class ImageService : AbstractService<IImageRepos, ImageModel, GetImageDto, CreateImageDto, UpdateImageDto>,
    IImageService
{
    public ImageService(IMapper mapper, IImageRepos repository) : base(mapper, repository)
    {
    }
}
