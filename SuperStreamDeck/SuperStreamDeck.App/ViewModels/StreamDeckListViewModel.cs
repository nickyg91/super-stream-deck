using System.Collections.Generic;
using System.Collections.ObjectModel;
using SuperStreamDeck.Driver.Devices;
using SuperStreamDeck.Driver.Devices.Base;

namespace SuperStreamDeck.App.ViewModels;

public class StreamDeckListViewModel : ViewModelBase
{
    private readonly IDeviceManager _deviceManager;

    public StreamDeckListViewModel()
    {
        // Default constructor for design-time data
    }
    
    public StreamDeckListViewModel(IDeviceManager deviceManager)
    {
        _deviceManager = deviceManager;
    }
    
    public ObservableCollection<StreamDeck> StreamDecks
    {
        get
        {
            var streamDecks = _deviceManager.GetConnectedStreamDeckDevices();
            return new ObservableCollection<StreamDeck>(streamDecks);
        }
    }
}