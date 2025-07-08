using OpenMacroBoard.SDK;
using StreamDeckSharp;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Models;

public class Profile(
    string name,
    Dictionary<int, KeySetting> keys,
    StreamDeckDeviceReference device)
{
    private IMacroBoard? _macroBoard;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public Dictionary<int, KeySetting> Keys { get; set; } = keys;
    public StreamDeckDeviceReference Device { get; } = device;

    public void SetProfile()
    {
        _macroBoard = Device.Open(true);
        if (_macroBoard is null || !_macroBoard.IsConnected)
        {
            throw new Exception("StreamDeck is not connected.");
        }
    }
    
    public void ClearKeys()
    {
        if (_macroBoard is null || !_macroBoard.IsConnected)
        {
            throw new Exception("StreamDeck is not connected.");
        }
        _macroBoard.ClearKeys();
    }
    
    public void SetKey(int keyIndex, KeySetting keySetting)
    {
        if (_macroBoard is null || !_macroBoard.IsConnected)
        {
            throw new Exception("StreamDeck is not connected.");
        }
        _macroBoard.SetKeyBitmap(keyIndex, keySetting.BackgroundImage);
        _macroBoard.SetKeyText(keyIndex, keySetting.Text);
        if (keySetting.Event is not null)
        {
            _macroBoard.KeyStateChanged += (s, e) =>
            {
                if (e.KeyNumber == keyIndex && e.IsDown)
                {
                    keySetting.Event.Invoke(this, EventArgs.Empty);
                }
            };
        }
    }
}