using FluentValidation;

namespace Hotel.UI.Features.Rooms.Form;

public class RoomModel
{
    public int Id { get; set; }
    public string RoomNo { get; set; } = "";
    public int NumOfBeds { get; set; }
}

public class RoomModelValidator : AbstractValidator<RoomModel>
{
    public RoomModelValidator()
    {
        RuleFor(x => x.RoomNo).NotEmpty().WithMessage("Toa nr. puudub");
        RuleFor(x => x.NumOfBeds).GreaterThan(0).WithMessage("Tuba peab olema vähemalt 1 kohaline")
            .LessThan(6).WithMessage("Tuba saab olla maksimaalselt 5 kohaline");
    }
}