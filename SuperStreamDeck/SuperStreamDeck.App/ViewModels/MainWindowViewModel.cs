namespace SuperStreamDeck.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ProfileListViewModel ProfileListViewModel { get; }

    public MainWindowViewModel(ProfileListViewModel profileListViewModel)
    {
        ProfileListViewModel = profileListViewModel;
    }
}