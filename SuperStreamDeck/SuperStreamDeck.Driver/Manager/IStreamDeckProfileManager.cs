using OpenMacroBoard.SDK;
using StreamDeckSharp;
using SuperStreamDeck.Driver.Models;

namespace SuperStreamDeck.Driver.Manager;

public interface IStreamDeckProfileManager
{
    public IReadOnlyDictionary<Guid, Profile> GetAllProfiles();
    public event EventHandler? ProfilesChanged;
    public void AddProfile(Profile profile);
    public void UpdateProfile(Profile profile);
    public void DeleteProfile(Guid id);
    public void SetDeckProfile(Profile profile);
}