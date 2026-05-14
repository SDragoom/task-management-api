using FluentValidation;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Validators;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskDto>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.DueDate)
            .Must(d => d >= DateTime.Today)
            .When(x => x.DueDate.HasValue);
    }
}