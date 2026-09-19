using EnterprisePortal.Api;using Microsoft.EntityFrameworkCore;
namespace EnterprisePortal.Tests;
public class MemberServiceTests {
 [Fact] public async Task CreatesMember(){
  var o=new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;using var db=new AppDbContext(o);var s=new MemberService(db);
  var m=await s.Create("Synthetic Member","member@example.test");Assert.Equal("Synthetic Member",m.Name);
 }
 [Fact] public async Task MissingRegistrationReferencesReturnNull(){
  var o=new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;using var db=new AppDbContext(o);var s=new MemberService(db);
  Assert.Null(await s.Register(99,88));
 }
}
