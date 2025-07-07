using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;
using SuperStreamDeck.App.Messages;
using SuperStreamDeck.App.ViewModels;

namespace SuperStreamDeck.App.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Design.IsDesignMode)
        {
            return;
        }

        WeakReferenceMessenger.Default.Register<MainWindow, AddProfileDialogOpenedMessage>(this, static (w, m) =>
        {
            var dialog = new AddProfileDialog
            {
                DataContext = new AddProfileViewModel()
            };
            m.Reply(dialog.ShowDialog<AddProfileViewModel?>(w));
        });
    }
}