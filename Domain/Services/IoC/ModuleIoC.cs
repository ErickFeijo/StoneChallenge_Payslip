using Autofac;
using StoneChallenge_Payslip.Domain.Interfaces;
using StoneChallenge_Payslip.Service.Services;

namespace StoneChallenge_Payslip.Domain.IoC
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
