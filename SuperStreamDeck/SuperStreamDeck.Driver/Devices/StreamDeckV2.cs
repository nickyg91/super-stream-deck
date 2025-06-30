using System.Text.Unicode;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Devices;

public class StreamDeckV2 : Base.StreamDeck, IDisposable
{
    private readonly UsbEndpointReader _reader;
    private readonly UsbEndpointWriter _writer;
    
    public StreamDeckV2(UsbDevice? device) : base(15, 72, 72, 3, 5, [ImageType.PNG, ImageType.JPEG, ImageType.GIF])
    {
        if (device == null)
        {
            throw new ArgumentNullException(nameof(device), "Device cannot be null");
        }
        device.Open();
        var interfaceNumber = device.Configs[0].Interfaces[0].Number;
        if (device.IsKernelDriverActive(interfaceNumber))
        {
            device.DetachKernelDriver(interfaceNumber);
        }
        device.ClaimInterface(interfaceNumber);
        _reader = device.OpenEndpointReader(ReadEndpointID.Ep01);
        _writer = device.OpenEndpointWriter(WriteEndpointID.Ep01);
        Task.Run(async () => await OpenReadStream());
    }
    public override StreamDeckType StreamDeckType => StreamDeckType.OriginalStreamDeckV2;
    protected override async Task WriteData(string data)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(data);
        var result = await _writer.WriteAsync(bytes, 1000);
        if (result.error != Error.Success)
        {
            throw new Exception($"Error writing data: {result.error}");
        }
    }

    protected override async Task<byte[]> ReadData()
    {
        //await OpenReadStream();
        throw new NotImplementedException();
    }
    
    private async Task OpenReadStream()
    {
        while (true)
        {
            var buffer = new byte[512];
            var result = await _reader.ReadAsync(buffer, 0, 512, 12000);
            // slice off first four bytes
            // take next 15 items (each index is a key)
            var segment = new ArraySegment<byte>(buffer, 4, 15);
            if (result.error != Error.Success)
            {
                continue;
            }
            var buttonPressedIndex = Array.IndexOf(segment.Array!, (byte)1, segment.Offset, segment.Count);
            if (buttonPressedIndex > 0)
            {
                Console.WriteLine($"Button Pressed: {buttonPressedIndex - segment.Offset + 1}");
            }
        }
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}