using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SuperStreamDeck.Driver.Devices;

namespace SuperStreamDeck.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(StreamDeckListViewModel streamDeckListViewModel)
    {
        StreamDeckListViewModel = streamDeckListViewModel;
    }
    public StreamDeckListViewModel StreamDeckListViewModel { get; }
}