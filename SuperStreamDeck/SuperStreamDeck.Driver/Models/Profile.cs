using OpenMacroBoard.SDK;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Models;

public class Profile
{
    public Guid Id { get; set; }
    public StreamDeckType StreamDeckType { get; set; }
    public string Name { get; set; }
    public Dictionary<int, KeySetting> Keys { get; set; }
}