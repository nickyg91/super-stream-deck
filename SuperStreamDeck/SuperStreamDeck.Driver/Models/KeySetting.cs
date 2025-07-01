namespace SuperStreamDeck.Driver.Models;

public class KeySetting
{
    public string Text { get; set; }
    public byte[] BackgroundImage { get; set; }
    public EventHandler Event { get; set; }
}