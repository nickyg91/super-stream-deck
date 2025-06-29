using Microsoft.Extensions.DependencyInjection;
using SuperStreamDeck.Driver.Devices;
using SuperStreamDeck.App.ViewModels;

namespace SuperStreamDeck.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<StreamDeckListViewModel>();
        collection.AddSingleton<IDeviceManager, DeviceManager>();
    }
}