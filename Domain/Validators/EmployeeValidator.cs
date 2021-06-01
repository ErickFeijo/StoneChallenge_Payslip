using FluentValidation;
using StoneChallenge_Payslip.Domain.Entities;

namespace StoneChallenge_Payslip.Service.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the Name.")
                .NotNull().WithMessage("Please enter the Name.");

            RuleFor(c => c.Identification)
                .NotEmpty().WithMessage("Please enter the Identification.")
                .NotNull().WithMessage("Please enter the Identification.");

            RuleFor(c => c.Admission)
                .NotEmpty().WithMessage("Please enter the Admission.")
                .NotNull().WithMessage("Please enter the Admission.");

            RuleFor(c => c.Salary)
                .NotEmpty().WithMessage("Please enter the Salary.")
                .NotNull().WithMessage("Please enter the Salary.");
        }
    }
}
