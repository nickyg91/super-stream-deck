using System.ComponentModel;

namespace SuperStreamDeck.Driver.Enums;

public enum StreamDeckType : byte
{
    [Description("Stream Deck")]
    OriginalStreamDeck = 1,
    [Description("Stream Deck V2")]
    OriginalStreamDeckV2 = 2,
    [Description("Stream Deck Mini")]
    StreamDeckMini = 3,
    [Description("Stream Deck Neo")]
    StreamDeckNeo = 4,
    [Description("Stream Deck XL")]
    StreamDeckXL = 5,
    [Description("Stream Deck MK2")]
    StreamDeckMK2 = 6,
    [Description("Stream Deck Pedal")]
    StreamDeckPedal = 7,
    [Description("Stream Deck Plus")]
    StreamDeckPlus = 8,
}