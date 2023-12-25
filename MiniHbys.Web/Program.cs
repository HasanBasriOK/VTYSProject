using MiniHbys.Business.Abstraction;
using MiniHbys.Business.Services;
using MiniHbys.DataAccess.Abstraction;
using MiniHbys.DataAccess.Managers;
using MiniHbys.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IOC

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IDepartmentManager, DepartmentManager>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDoctorManager, DoctorManager>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPatientManager, PatientManager>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IRoleManager, RoleManager>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IInspectionManager, InspectionManager>();
builder.Services.AddTransient<IInspectionService, InspectionService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
#endregion

var app = builder.Build();
var services = builder.Services;
var configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

GlobalSettings.ConnectionString = configuration.GetSection("ConnectionString").Value ?? string.Empty;






app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.Run();