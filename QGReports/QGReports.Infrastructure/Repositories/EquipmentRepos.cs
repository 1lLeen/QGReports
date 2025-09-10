using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;
public class EquipmentRepos : AbstractRepository<EquipmentModel>,
    IEquipmentRepos
{
    public EquipmentRepos(QGReportsDbContext context) : base(context)
    {
    }
}
