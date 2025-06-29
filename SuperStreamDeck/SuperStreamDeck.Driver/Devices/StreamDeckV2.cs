using System.Text.Unicode;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using SuperStreamDeck.Driver.Enums;

namespace SuperStreamDeck.Driver.Devices;

public class StreamDeckV2 : Base.StreamDeck, IDisposable
{
    private readonly IUsbDevice _device;
    private readonly UsbEndpointReader _reader;
    private readonly UsbEndpointWriter _writer;
    
    public StreamDeckV2(IUsbDevice device) : base(15, 72, 72, 3, 5, [ImageType.PNG, ImageType.JPEG, ImageType.GIF])
    {
        _device = device;
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
        var buffer = new byte[64];
        while (true)
        {
            var result = await _reader.ReadAsync(buffer, 1000);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer));
            if (result.error != Error.Success)
            {
                throw new Exception($"Error reading data: {result.error}");
            }
            // Process the data in buffer
        }
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}