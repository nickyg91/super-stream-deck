using StreamDeck.Driver.Enums;

namespace StreamDeck.Driver;

public abstract class StreamDeck
{
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
}