using FluentValidation;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Validators;

public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.DueDate)
            .Must(BeFutureDate)
            .When(x => x.DueDate.HasValue)
            .WithMessage("Due date must be today or in the future.");
    }

    private bool BeFutureDate(DateTime? date)
    {
        return date >= DateTime.Today;
    }
}