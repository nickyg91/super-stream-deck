using LibUsbDotNet;
using LibUsbDotNet.Main;
using StreamDeck.Driver.Enums;

namespace StreamDeck.Driver.Devices;

public class DeviceManager
{
    private const int ELGATO_VID = 0x0fd9;
    public DeviceManager()
    {
    }

    public IEnumerable<string> GetConnectedStreamDeckDevices()
    {
        UsbRegDeviceList list = UsbDevice.AllDevices;
        foreach (UsbDevice device in list)
        {
            switch ((StreamDeckType)device.UsbRegistryInfo.Pid)
            {
                case StreamDeckType.OriginalSteamDeck:
                case StreamDeckType.OriginalStreamDeckV2:
                case StreamDeckType.StreamDeckMini:
                case StreamDeckType.StreamDeckNeo:
                case StreamDeckType.StreamDeckXL:
                case StreamDeckType.StreamDeckMK2:
                case StreamDeckType.StreamDeckPedal:
                case StreamDeckType.StreamDeckPlus:
                    yield return device.Info.ProductString;
                    break;
            }
        }
    }
}