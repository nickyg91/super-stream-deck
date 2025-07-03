using Microsoft.Extensions.DependencyInjection;
using SuperStreamDeck.App.ViewModels;
using SuperStreamDeck.Driver.Manager;

namespace SuperStreamDeck.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IStreamDeckProfileManager, StreamDeckProfileManager>();
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<ProfileListViewModel>();
    }
}