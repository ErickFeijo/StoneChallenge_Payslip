using Autofac;
using WarzoneLobbyOrganizer.Domain.Interfaces;
using WarzoneLobbyOrganizer.Service.Services;

namespace WarzoneLobbyOrganizer.Infra.CrossCutting.IoC
{
    public class ModuleIoCService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseService<Domain.Entities.Employee>>().As<IBaseService<Domain.Entities.Employee>>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
        }
    }
}
