using Core.Domain;
using Core.Domain.Common;
using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.DatabaseContext;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {

    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveDistribution> LeaveDistributions { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TeamUser> TeamsUsers{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LeaveRequest>()
        .OwnsOne(lr => lr.Duration);

        modelBuilder.Entity<LeaveRequest>()
                .Property(f => f.RequestStatus)
                .HasConversion<string>();

        modelBuilder.Entity<Candidate>()
                .Property(f => f.StackPosition)                
                .HasConversion<string>();

        modelBuilder.Entity<Candidate>()
                .Property(f => f.Seniority)
                .HasConversion<string>();

        modelBuilder.Entity<User>()
                .Property(f => f.Seniority)
                .HasConversion<string>();

        modelBuilder.Entity<User>()
        .Property(f => f.StackPosition)
        .HasConversion<string>();

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityUser<string>>();
        modelBuilder.Ignore<ApplicationUser>();
        modelBuilder.Ignore<IdentityRole>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    SoftDelete();
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SoftDelete()
    {
        ChangeTracker.DetectChanges();

        var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

        foreach (var item in markedAsDeleted)
        {
            if (item.Entity is IAffectedDateTimes entity)
            {
                entity.DeletedDate = DateTime.UtcNow;
            }
        }
    }
}
