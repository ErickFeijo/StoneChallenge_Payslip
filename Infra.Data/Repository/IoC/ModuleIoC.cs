using Autofac;
using StoneChallenge_Payslip.Domain.Interfaces;
using StoneChallenge_Payslip.Infra.Data.Repository;

namespace StoneChallenge_Payslip.Infra.Data.IoC
{
    public class ModuleIoCRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseRepository<Domain.Entities.Employee>>().As<IBaseRepository<Domain.Entities.Employee>>();
        }
    }
}
