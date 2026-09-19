using Microsoft.EntityFrameworkCore;
namespace EnterprisePortal.Api;
public class AppDbContext(DbContextOptions<AppDbContext> o):DbContext(o) {
 public DbSet<Member> Members=>Set<Member>(); public DbSet<Engagement> Engagements=>Set<Engagement>(); public DbSet<Event> Events=>Set<Event>(); public DbSet<Registration> Registrations=>Set<Registration>();
 protected override void OnModelCreating(ModelBuilder b) {
  b.Entity<Member>().HasIndex(x=>x.Email).IsUnique();
  b.Entity<Registration>().HasIndex(x=>new{x.MemberId,x.EventId}).IsUnique();
 }
}
