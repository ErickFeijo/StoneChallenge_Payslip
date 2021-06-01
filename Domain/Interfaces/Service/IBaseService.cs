using FluentValidation;
using StoneChallenge_Payslip.Domain.Entities;
using System.Collections.Generic;

namespace StoneChallenge_Payslip.Domain.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        TOutputModel GetPayslip<TOutputModel>(int idEmployee);
    }
}
