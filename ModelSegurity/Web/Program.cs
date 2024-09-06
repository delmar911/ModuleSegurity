using Business.Implements;
using Business.Interface;
using Data.Implements;
using Data.Interface;
using Entity.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

//city
builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();
//country
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<ICountryData, CountryData>();
//Department
builder.Services.AddScoped<IDepartmetBusiness, DepartmentBusiness>();
builder.Services.AddScoped<IDepartmentData, DepartmentData>();
//module
builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();
builder.Services.AddScoped<IModuleData, ModuleData>();
//Person
builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IPersonData, PersonData>();
//Role
builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleData, RoleData>();
//RoleViewData
builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();
//User
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserData, UserData>();
//UserRole
builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();
//view
builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
builder.Services.AddScoped<IViewData, ViewData>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
