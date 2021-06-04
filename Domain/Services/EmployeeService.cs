using AutoMapper;
using FluentValidation;
using StoneChallenge_Payslip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using StoneChallenge_Payslip.Domain.Interfaces;
using StoneChallenge_Payslip.Domain;

namespace StoneChallenge_Payslip.Service.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IBaseRepository<Employee> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
        }

        public TOutputModel GetPayslip<TOutputModel>(int idEmployee)
        {
            var employee = _baseRepository.Select(idEmployee);

            if (employee is null)
                throw new ArgumentException("Employee not found.");

            DateTime latestMonth = DateTime.Today.AddMonths(-1);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(new Payslip(employee, latestMonth));

            return outputModel;
        }
    }
}
