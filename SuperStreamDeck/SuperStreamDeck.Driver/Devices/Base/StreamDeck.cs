using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Devices.Base;

public abstract class StreamDeck
{
    private readonly int _elgatoVid = 0x0fd9;
    public virtual StreamDeckType StreamDeckType { get; }

    protected StreamDeck(
        byte keyCount,
        byte keyPixelHeight,
        byte keyPixelWidth,
        byte rows, 
        byte columns,
        ImageType[] supportedImageTypes)
    {
        KeyCount = keyCount;
        Rows = rows;
        Columns = columns;
        SupportedImageTypes = supportedImageTypes;
        KeyPixelHeight = keyPixelHeight;
        KeyPixelWidth = keyPixelWidth;
    }
    
    public byte KeyCount { get; init; }
    public byte Rows { get; init; }
    public byte Columns { get; init; }
    public byte KeyPixelHeight { get; init; }
    public byte KeyPixelWidth { get; init; }
    public ImageType[] SupportedImageTypes { get; init; }

    public string Name
    {
        get
        {
            return StreamDeckType switch
            {
                StreamDeckType.OriginalStreamDeck => "Stream Deck",
                StreamDeckType.OriginalStreamDeckV2 => "Stream Deck V2",
                StreamDeckType.StreamDeckMini => "Stream Deck Mini",
                StreamDeckType.StreamDeckNeo => "Stream Deck Neo",
                StreamDeckType.StreamDeckXL => "Stream Deck XL",
                StreamDeckType.StreamDeckMK2 => "Stream Deck MK2",
                StreamDeckType.StreamDeckPedal => "Stream Deck Pedal",
                StreamDeckType.StreamDeckPlus => "Stream Deck Plus",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    protected abstract Task WriteData(string data);

    protected abstract Task<byte[]> ReadData();
}