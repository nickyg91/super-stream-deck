using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StreamDeck.Driver.Devices;

namespace SuperStreamDeck.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly DeviceManager _deviceManager;
    public MainWindowViewModel()
    {
        _deviceManager = new DeviceManager();
        StreamDecks = new ObservableCollection<string>(_deviceManager.GetConnectedStreamDeckDevices());
    }
    public ObservableCollection<string> StreamDecks { get; }
    public string Greeting { get; } = "Welcome to Avalonia!";
}