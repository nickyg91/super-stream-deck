using SuperStreamDeck.App.ViewModels;

namespace SuperStreamDeck.App.Messages;

public class AddProfileDialogClosedMessage(AddProfileViewModel? profile)
{
    public AddProfileViewModel? Profile { get; } = profile;
}