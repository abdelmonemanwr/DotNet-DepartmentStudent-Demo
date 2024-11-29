using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApp.Models;
using myApp.Repository;
using myApp.Services;
using myApp.UnitOfWorks;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
    op => op.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<GenericRepository<Student>>();
builder.Services.AddScoped<GenericRepository<Department>>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ITIContext>(
    options => options.UseLazyLoadingProxies().UseSqlServer(
        builder.Configuration.GetConnectionString("ITIConnectionString")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string corsPolicies = "";
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(corsPolicies, builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable using swagger in the production mode and development mode
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicies);
app.MapControllers();

app.Run();