using FluentValidation;
using FluentValidation.Results;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application;

public class ApplicationAbstractValidator<T> : AbstractValidator<T>
{
    public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = new CancellationToken())
    {
        var validationResult = await base.ValidateAsync(context, cancellation);

        if (!validationResult.IsValid)
        {
            throw new ApplicationException(string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage)));
        }

        return validationResult;
    }
}