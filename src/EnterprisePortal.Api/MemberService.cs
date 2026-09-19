using Microsoft.EntityFrameworkCore;
namespace EnterprisePortal.Api;
public class MemberService(AppDbContext db) {
 public Task<List<Member>> List()=>db.Members.AsNoTracking().Include(x=>x.Engagements).ToListAsync();
 public async Task<Member> Create(string name,string email) { var x=new Member{Name=name,Email=email};db.Members.Add(x);await db.SaveChangesAsync();return x; }
 public async Task<Registration?> Register(int memberId,int eventId) {
  if(!await db.Members.AnyAsync(x=>x.Id==memberId)||!await db.Events.AnyAsync(x=>x.Id==eventId))return null;
  var r=new Registration{MemberId=memberId,EventId=eventId};db.Registrations.Add(r);await db.SaveChangesAsync();return r;
 }
}
