using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentApi;
using FluentApi.Data;
using FluentApi.Model;
using FluentApi.Repository;
using FluentApi.Service;
using FluentApi.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    //container.RegisterType<StudentValidator>().As<IValidator<Student>>().InstancePerDependency();
    //container.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
    //container.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
    //container.RegisterType<DapperContext>().AsSelf().SingleInstance();
    container.RegisterModule(new AutofacModule());
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IValidator<Student>, StudentValidator>();
//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
       
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "Student",
    pattern: "student",
    defaults: new { controller = "Student", action = "CreateStudent" }
);

app.Run();
