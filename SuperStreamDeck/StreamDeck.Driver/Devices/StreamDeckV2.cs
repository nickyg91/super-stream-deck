using StreamDeck.Driver.Enums;

namespace StreamDeck.Driver.Devices;

public class StreamDeckV2 : StreamDeck
{
    public StreamDeckV2() : base(15, 72, 72, 3, 5, [ImageType.PNG, ImageType.JPEG, ImageType.GIF])
    {
    }
}