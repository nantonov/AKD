using DG.API.ViewModels;
using FluentValidation;

namespace DG.API.Validators;

public class ChangeDrawingViewModelValidator : AbstractValidator<ChangeDrawingViewModel>
{
    public ChangeDrawingViewModelValidator()
    {
        RuleFor(d => d.Description).NotEmpty();
        RuleFor(d => d.DrawingPhotoLink).NotEmpty();
        RuleFor(d => d.Description.Text).NotEmpty().MinimumLength(10);
        RuleFor(d => d.Description.Points).NotEmpty().MinimumLength(8);
        RuleFor(d => d.Description.DescriptionPhotoLink).NotEmpty();
    }
}