using StoneChallenge_Payslip.Application.Models;
using StoneChallenge_Payslip.Domain.Interfaces;
using StoneChallenge_Payslip.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StoneChallenge_Payslip.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService baseEmployeeService)
        {
            _employeeService = baseEmployeeService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEmployee Employee)
        {
            if (Employee == null)
                return NotFound();

            return Execute(() => _employeeService.Add<CreateEmployee, Models.Employee, EmployeeValidator>(Employee));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _employeeService.GetById<Models.Employee>(id));
        }

        [HttpGet("Payslip/{idEmployee}")]
        public IActionResult GetPayslip(int idEmployee)
        {
            if (idEmployee == 0)
                return NotFound();

            return Execute(() => _employeeService.GetPayslip<Models.Payslip>(idEmployee));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
