using Autofac;
using FluentApi.Data;
using FluentApi.Model;
using FluentApi.Repository;
using FluentApi.Service;
using FluentApi.Validation;
using FluentValidation;

namespace FluentApi
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentValidator>().As<IValidator<Student>>().InstancePerDependency();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DapperContext>().AsSelf().SingleInstance();
        }
    }
}
