using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSDU.Business;
using OSDU.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<OrganizationViewRepository>();
builder.Services.AddScoped<OrganizationViewService>();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<OsduDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OSDU")).UseOsduSeeding());
builder.Services.AddScoped<FacilityFieldRepository>();
builder.Services.AddScoped<FacilityFieldService>();
builder.Services.AddScoped<CrsRepository>();
builder.Services.AddScoped<CrsService>();
builder.Services.AddScoped<OrganizationUnitRepository>();
builder.Services.AddScoped<OrganizationUnitService>();
builder.Services.AddScoped<PoolRepository>();
builder.Services.AddScoped<PoolService>();
builder.Services.AddScoped<EquipmentRepository>();
builder.Services.AddScoped<EquipmentService>();
builder.Services.AddScoped<FieldTypeRepository>();
builder.Services.AddScoped<FieldTypeService>();
builder.Services.AddScoped<FieldRepository>();
builder.Services.AddScoped<FieldService>();
builder.Services.AddScoped<WellRepository>();
builder.Services.AddScoped<WellService>();
builder.Services.AddScoped<AssetRepository>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<FacilityRepository>();
builder.Services.AddScoped<FacilityService>();
builder.Services.AddScoped<WellStatusTypeRepository>();
builder.Services.AddScoped<WellStatusTypeService>();
builder.Services.AddScoped<WellStatusRepository>();
builder.Services.AddScoped<WellStatusService>();
builder.Services.AddScoped<OrgUnitTypeRepository>();
builder.Services.AddScoped<OrgUnitTypeService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(o => {
 o.User.RequireUniqueEmail = true;
 o.Password.RequiredLength = 12;
 o.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<OsduDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(o => {
 o.Cookie.Name = "OSDU.Session";
 o.Cookie.HttpOnly = true;
 o.Cookie.SameSite = SameSiteMode.Strict;
 o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
 o.ExpireTimeSpan = TimeSpan.FromHours(8);
 o.Events.OnRedirectToLogin = c => { c.Response.StatusCode = 401; return Task.CompletedTask; };
 o.Events.OnRedirectToAccessDenied = c => { c.Response.StatusCode = 403; return Task.CompletedTask; };
});
builder.Services.AddAuthorization();
var app = builder.Build();
if (builder.Configuration.GetValue<bool>("seed-data")) {
 using var scope = app.Services.CreateScope();
 await scope.ServiceProvider.GetRequiredService<OsduDbContext>().Database.MigrateAsync();
 return;
}
app.UseAuthentication();
app.UseAuthorization();
// Optional one-time account provisioning; passwords never enter source control.
if (builder.Configuration["Bootstrap:Password"] is { Length: > 0 } bootstrapPassword) {
 using var scope = app.Services.CreateScope();
 var users = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
 var email = builder.Configuration["Bootstrap:Email"] ?? "admin@osdu.local";
 if (await users.FindByEmailAsync(email) is null) {
  var result = await users.CreateAsync(new IdentityUser { UserName = email, Email = email }, bootstrapPassword);
  if (!result.Succeeded) throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));
 }
}

app.UseExceptionHandler();
if (app.Environment.IsDevelopment()) app.MapOpenApi();
app.MapGet("/", () => Results.Ok(new { application="OSDU", api="/api/assets" }));
app.MapControllers().RequireAuthorization();
app.Run();

