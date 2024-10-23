using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
          new LeaveType
          {
              Id = 1,
              Uid = Guid.NewGuid(),
              Name = "Vacation",
              DefaultDays = 21,
              CreatedDate = DateTime.Now,
              RequiresHRApproval = true
          },
          new LeaveType
          {
              Id = 2,
              Uid = Guid.NewGuid(),
              Name = "Old Vacation",
              DefaultDays = 15,
              CreatedDate = DateTime.Now,
              RequiresHRApproval = true
          },
          new LeaveType
          {
              Id = 4,
              Uid = Guid.NewGuid(),
              Name = "Remote Work",
              DefaultDays = 15,
              CreatedDate = DateTime.Now,
              RequiresHRApproval = true
          },
          new LeaveType
          {
              Id = 5,
              Uid = Guid.NewGuid(),
              Name = "Sick Leave",
              DefaultDays = 365,
              CreatedDate = DateTime.Now,
              RequiresHRApproval = false
          }

    );

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.DefaultDays)
            .IsRequired();

        builder.Property(x => x.Uid)
            .IsRequired();
    }
}
