using Autofac;
using WarzoneLobbyOrganizer.Domain.Interfaces;
using WarzoneLobbyOrganizer.Infra.Data.Repository;

namespace WarzoneLobbyOrganizer.Infra.CrossCutting.IoC
{
    public class ModuleIoCRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseRepository<Domain.Entities.Employee>>().As<IBaseRepository<Domain.Entities.Employee>>();
        }
    }
}
