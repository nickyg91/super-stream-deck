using StreamDeckSharp;

namespace SuperStreamDeck.Driver.Managers;

public class StreamDeckManager : IStreamDeckManager
{
    public List<StreamDeckDeviceReference> GetStreamDecks()
    {
        var decks = StreamDeck.EnumerateDevices();
        return decks == null ? [] : decks.ToList();
    }
}