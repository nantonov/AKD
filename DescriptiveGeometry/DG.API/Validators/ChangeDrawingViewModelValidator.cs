using DG.API.ViewModels;
using FluentValidation;

namespace DG.API.Validators;

public class ChangeDrawingViewModelValidator : AbstractValidator<ChangeDrawingViewModel>
{
    public ChangeDrawingViewModelValidator()
    {
        RuleFor(d => d.Description).NotNull();
        RuleFor(d => d.DrawingPhotoLink).NotNull();
        RuleFor(d => d.Description.Text).MinimumLength(10);
        RuleFor(d => d.Description.Points).MinimumLength(8);
        RuleFor(d => d.Description.DescriptionPhotoLink).NotNull();
    }
}