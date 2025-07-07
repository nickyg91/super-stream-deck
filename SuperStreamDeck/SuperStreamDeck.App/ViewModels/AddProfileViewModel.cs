using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SuperStreamDeck.App.Messages;
using SuperStreamDeck.Driver.Enums;
using SuperStreamDeck.Model.Enums;

namespace SuperStreamDeck.App.ViewModels;

public partial class AddProfileViewModel : ViewModelBase
{
    [Required, MaxLength(256)]
    public string Name { get; set; }
    [Required]
    public StreamDeckType? StreamDeckType { get; set; }
    public List<EnumDescription<StreamDeckType>> StreamDeckTypes { get; } =
        Enum.GetValues<StreamDeckType>()
            .Select(e => new EnumDescription<StreamDeckType>
            {
                Value = e,
                Description = e.GetDescription()
            })
            .ToList();

    [RelayCommand]
    public void SaveProfile()
    {
        if (!string.IsNullOrEmpty(Name) && StreamDeckType == null)
        {
            return;
        }
        WeakReferenceMessenger.Default.Send(new AddProfileDialogClosedMessage(this));
    }
    
    [RelayCommand]
    public void Cancel()
    {
        WeakReferenceMessenger.Default.Send(new AddProfileDialogClosedMessage(null));
    }
}