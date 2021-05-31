using FluentValidation;
using WarzoneLobbyOrganizer.Domain.Entities;

namespace WarzoneLobbyOrganizer.Service.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the Name.")
                .NotNull().WithMessage("Please enter the Name.");

            //RuleFor(c => c.Creator)
            //    .NotEmpty().WithMessage("Please enter the Creator.")
            //    .NotNull().WithMessage("Please enter the Creator.");

            //RuleFor(c => c.TeamSize)
            //    .NotEmpty().WithMessage("Please enter the Team Size.")
            //    .NotNull().WithMessage("Please enter the Team Size.");

            //TODO
            //RuleForEach(c => c.Teams).Must(c => c.Players ChildRules(c => c.(c => c.Players))
            //    .NotEmpty().WithMessage("All teams need respect Team Size.")
            //    .NotNull().WithMessage("Please enter the Team Size.");


        }
    }
}
