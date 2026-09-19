namespace EnterprisePortal.Api;
public class Member { public int Id {get;set;} public required string Name {get;set;} public required string Email {get;set;} public List<Engagement> Engagements {get;set;}=[]; }
public class Engagement { public int Id {get;set;} public int MemberId {get;set;} public required string Type {get;set;} public DateTime OccurredAt {get;set;}=DateTime.UtcNow; }
public class Event { public int Id {get;set;} public required string Name {get;set;} public DateTime StartsAt {get;set;} public int Capacity {get;set;} }
public class Registration { public int Id {get;set;} public int MemberId {get;set;} public int EventId {get;set;} public DateTime RegisteredAt {get;set;}=DateTime.UtcNow; }
