using OpenMacroBoard.SDK;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Models;

public class Profile(
    string name,
    StreamDeckType streamDeckType,
    Dictionary<int, KeySetting> keys)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public StreamDeckType StreamDeckType { get; set; } = streamDeckType;
    public string Name { get; set; } = name;
    public Dictionary<int, KeySetting> Keys { get; set; } = keys;
}