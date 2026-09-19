using EnterprisePortal.Api;
using Microsoft.EntityFrameworkCore;
var b=WebApplication.CreateBuilder(args);
var cs=b.Configuration.GetConnectionString("Default");
if(string.IsNullOrWhiteSpace(cs)) b.Services.AddDbContext<AppDbContext>(x=>x.UseInMemoryDatabase("portal"));
else b.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(cs));
b.Services.AddScoped<MemberService>();b.Services.AddApplicationInsightsTelemetry();b.Services.AddHealthChecks();
var app=b.Build();app.MapHealthChecks("/health");
app.MapGet("/members",(MemberService s)=>s.List());
app.MapPost("/members",async(MemberCreate x,MemberService s)=>Results.Created("/members",await s.Create(x.Name,x.Email)));
app.MapPost("/registrations",async(RegisterRequest x,MemberService s)=>{var r=await s.Register(x.MemberId,x.EventId);return r is null?Results.NotFound():Results.Created($"/registrations/{r.Id}",r);});
app.Run();
public record MemberCreate(string Name,string Email); public record RegisterRequest(int MemberId,int EventId);
public partial class Program {}
