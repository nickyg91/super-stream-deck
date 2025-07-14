using System.Collections.Generic;
using StreamDeckSharp;
using SuperStreamDeck.Driver.Managers;

namespace SuperStreamDeck.App.ViewModels;

public partial class StreamDeckListViewModel : ViewModelBase
{
    private readonly IStreamDeckManager _streamDeckManager;

    public StreamDeckListViewModel(IStreamDeckManager streamDeckManager)
    {
        _streamDeckManager = streamDeckManager;
    }
    
    public List<StreamDeckDeviceReference> StreamDecks => _streamDeckManager.GetStreamDecks();
}