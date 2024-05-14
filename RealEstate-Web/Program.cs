using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.Entities.Role;
using RealEstate_IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region dbcontext

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

#region Add Identity

builder.Services.AddDefaultIdentity<UserModel>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

#endregion

#region LoC

DependencyContainer.RejosterService(builder.Services);

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizationPolicies.AdminPolicy, p => p.RequireRole(Roles.Admin));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Identity/Admin", AuthorizationPolicies.AdminPolicy);
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
