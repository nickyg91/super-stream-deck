namespace SuperStreamDeck.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ProfileListViewModel ProfileListViewModel { get; }
    public StreamDeckListViewModel StreamDeckListViewModel { get; }

    public MainWindowViewModel(
        ProfileListViewModel profileListViewModel,
        StreamDeckListViewModel streamDeckListViewModel
        )
    {
        ProfileListViewModel = profileListViewModel;
        StreamDeckListViewModel = streamDeckListViewModel;
    }
}