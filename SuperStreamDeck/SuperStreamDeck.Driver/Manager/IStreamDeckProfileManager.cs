using OpenMacroBoard.SDK;
using StreamDeckSharp;
using SuperStreamDeck.Driver.Models;

namespace SuperStreamDeck.Driver.Manager;

public interface IStreamDeckProfileManager
{
    public List<Profile> GetProfiles();
    public Profile? GetProfile(Guid id);
    public void AddProfile(Profile profile);
    public void UpdateProfile(Profile profile);
    public void DeleteProfile(Guid id);
    public Task SetDeckProfile(Profile profile, IMacroBoard streamDeck);
}