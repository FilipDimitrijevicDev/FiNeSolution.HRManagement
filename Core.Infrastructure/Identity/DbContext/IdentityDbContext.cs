using Core.Domain;
using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Identity.DbContext;

public class IdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

        modelBuilder.Ignore<Candidate>();
        modelBuilder.Ignore<Company>();
        modelBuilder.Ignore<LeaveDistribution>();
        modelBuilder.Ignore<LeaveRequest>();
        modelBuilder.Ignore<LeaveType>();
        modelBuilder.Ignore<Team>();
        modelBuilder.Ignore<TeamUser>();
        modelBuilder.Ignore<User>();


        base.OnModelCreating(modelBuilder);
    }
}
