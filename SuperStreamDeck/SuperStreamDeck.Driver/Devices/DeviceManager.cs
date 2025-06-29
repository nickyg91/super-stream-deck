
using LibUsbDotNet.LibUsb;
using SuperStreamDeck.Driver.Devices.Base;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Devices;

public class DeviceManager : IDeviceManager, IDisposable
{
    private const int ELGATO_VID = 0x0fd9;
    private readonly UsbContext _context;
    public DeviceManager()
    {
        _context = new UsbContext();
    }

    public List<StreamDeck> GetConnectedStreamDeckDevices()
    {
        var streamDecks = new List<Base.StreamDeck>();
        var devices = _context.List().Where(x => x.VendorId == ELGATO_VID).ToList();
        foreach (var device in devices)
        {
            switch ((StreamDeckType)device.ProductId)
            {
                case StreamDeckType.OriginalStreamDeck:
                case StreamDeckType.OriginalStreamDeckV2:
                    streamDecks.Add(new StreamDeckV2(device));
                    break;
                case StreamDeckType.StreamDeckMini:
                case StreamDeckType.StreamDeckNeo:
                case StreamDeckType.StreamDeckXL:
                case StreamDeckType.StreamDeckMK2:
                case StreamDeckType.StreamDeckPedal:
                case StreamDeckType.StreamDeckPlus:
                    break;
            }
        }

        return streamDecks;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}