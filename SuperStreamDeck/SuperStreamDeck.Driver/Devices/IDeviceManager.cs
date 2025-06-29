namespace SuperStreamDeck.Driver.Devices;

public interface IDeviceManager
{
    List<Base.StreamDeck> GetConnectedStreamDeckDevices();
}