using System;
using System.Collections.Generic;
using SuperStreamDeck.Driver.Enums;
using SuperStreamDeck.Driver.Manager;
using SuperStreamDeck.Driver.Models;

namespace SuperStreamDeck.App.ViewModels;

public class ProfileListViewModel : ViewModelBase
{
    private readonly IStreamDeckProfileManager _profileManager;
    private Dictionary<Guid, Profile> _profiles = new();
    public ProfileListViewModel(IStreamDeckProfileManager profileManager)
    {
        _profileManager = profileManager;
        _profiles = new Dictionary<Guid, Profile>(_profileManager.GetAllProfiles());
        _profileManager.ProfilesChanged += OnProfilesChanged;
    }

    public void AddProfile()
    {
        _profileManager.AddProfile(new Profile("Test", StreamDeckType.OriginalStreamDeckV2, new Dictionary<int, KeySetting>()));
    }
    
    public IEnumerable<Profile> Profiles => _profiles.Values;
    
    private void OnProfilesChanged(object? sender, EventArgs e)
    {
        _profiles = new Dictionary<Guid, Profile>(_profileManager.GetAllProfiles());
        OnPropertyChanged(nameof(Profiles));
    }
}