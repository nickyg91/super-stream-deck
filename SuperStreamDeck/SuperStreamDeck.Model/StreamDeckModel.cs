using SuperStreamDeck.Driver.Devices.Base;
namespace SuperStreamDeck.Model;

public class StreamDeckModel
{
    private StreamDeck _selectedStreamDeck;
    
    public StreamDeck? SelectedStreamDeck => _selectedStreamDeck;
    
    public void SetSelectedStreamDeck(StreamDeck streamDeck)
    {
        _selectedStreamDeck = streamDeck;
    }
}