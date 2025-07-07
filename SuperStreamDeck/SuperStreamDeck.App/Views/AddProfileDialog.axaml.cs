using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Messaging;
using SuperStreamDeck.App.Messages;

namespace SuperStreamDeck.App.Views;

public partial class AddProfileDialog : Window
{
    public AddProfileDialog()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            return;
        }
        WeakReferenceMessenger.Default.Register<AddProfileDialog, AddProfileDialogClosedMessage>(this, (window, message) =>
        {
            window.Close(message.Profile);
        });
    }
}