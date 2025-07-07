using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SuperStreamDeck.App.Messages;
using SuperStreamDeck.Driver.Manager;
using SuperStreamDeck.Driver.Models;

namespace SuperStreamDeck.App.ViewModels;

public partial class ProfileListViewModel : ViewModelBase
{
    private readonly IStreamDeckProfileManager _profileManager;
    private Dictionary<Guid, Profile> _profiles;
    public ProfileListViewModel(IStreamDeckProfileManager profileManager)
    {
        _profileManager = profileManager;
        _profiles = new Dictionary<Guid, Profile>(_profileManager.GetAllProfiles());
        _profileManager.ProfilesChanged += OnProfilesChanged;
    }

    [RelayCommand]
    public async Task AddProfile()
    {
        var profile =  await WeakReferenceMessenger.Default.Send<AddProfileDialogOpenedMessage>().Response;
        if (profile is not null)
        {
            _profileManager.AddProfile(new Profile(profile.Name, profile.StreamDeckType!.Value, new Dictionary<int, KeySetting>()));
            OnProfilesChanged(this, EventArgs.Empty);
        }
    }
    
    public IEnumerable<Profile> Profiles => _profiles.Values;
    
    private void OnProfilesChanged(object? sender, EventArgs e)
    {
        _profiles = new Dictionary<Guid, Profile>(_profileManager.GetAllProfiles());
        OnPropertyChanged(nameof(Profiles));
    }
}