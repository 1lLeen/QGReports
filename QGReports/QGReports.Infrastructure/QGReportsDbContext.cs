using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QGReports.Domain.Models;
using QGReports.Infrastructure.Configuration;

namespace QGReports.Infrastructure;
public class QGReportsDbContext(DbContextOptions<QGReportsDbContext> options) : IdentityDbContext<UserModel>(options)
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ReportModel> Reports { get; set; } 
    public DbSet<EquipmentModel> Equipments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BaseConfiguration<ReportModel>());
        builder.ApplyConfiguration(new BaseConfiguration<EquipmentModel>());

        builder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedTime).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.UpdatedTime).HasDefaultValueSql("getutcdate()");
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Phone).IsUnique();
        });
    }
}
