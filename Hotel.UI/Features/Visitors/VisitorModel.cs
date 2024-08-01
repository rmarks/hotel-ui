using FluentValidation;

namespace Hotel.UI.Features.Visitors;

public class VisitorModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string IdCode { get; set; } = "";
    public string Email { get; set; } = "";
}

public class VisitorModelValidator : AbstractValidator<VisitorModel>
{
    public VisitorModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.IdCode).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}