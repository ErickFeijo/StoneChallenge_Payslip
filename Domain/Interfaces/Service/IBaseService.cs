using FluentValidation;
using WarzoneLobbyOrganizer.Domain.Entities;
using System.Collections.Generic;

namespace WarzoneLobbyOrganizer.Domain.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Payslip GetPayslip(int idEmployee);
    }
}
