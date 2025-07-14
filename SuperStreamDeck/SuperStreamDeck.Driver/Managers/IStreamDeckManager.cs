using StreamDeckSharp;

namespace SuperStreamDeck.Driver.Managers;

public interface IStreamDeckManager
{
    List<StreamDeckDeviceReference> GetStreamDecks();
}