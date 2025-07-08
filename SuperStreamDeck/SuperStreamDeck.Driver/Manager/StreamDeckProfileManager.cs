using OpenMacroBoard.SDK;
using SixLabors.ImageSharp.PixelFormats;
using SuperStreamDeck.Driver.Models;
using SixLabors.ImageSharp;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using PointF = SixLabors.ImageSharp.PointF;

namespace SuperStreamDeck.Driver.Manager;

public class StreamDeckProfileManager : IStreamDeckProfileManager
{
    private readonly Dictionary<Guid, Profile> _profiles = new();
    public IReadOnlyDictionary<Guid, Profile> GetAllProfiles() => _profiles;

    public event EventHandler? ProfilesChanged;
    public Profile? GetProfile(Guid id)
    {
        return _profiles.GetValueOrDefault(id);
    }

    public void AddProfile(Profile profile)
    {
        _profiles.Add(profile.Id, profile);
        ProfilesChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UpdateProfile(Profile profile)
    {
        if (_profiles.ContainsKey(profile.Id))
        {
            _profiles[profile.Id] = profile;
            ProfilesChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            throw new KeyNotFoundException($"Profile with ID {profile.Id} does not exist.");
        }
    }

    public void DeleteProfile(Guid id)
    {
        if (!_profiles.Remove(id))
        {
            throw new KeyNotFoundException($"Profile with ID {id} does not exist.");
        }
        ProfilesChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetDeckProfile(Profile profile)
    {
        if (!profile.Device.Open(true).IsConnected)
        {
            throw new Exception("StreamDeck is not connected.");
        }

        profile.ClearKeys();
        for (int i = 0; i < streamDeck.Keys.Count; i++)
        {
            if (!profile.Keys.TryGetValue(i, out var keySetting))
            {
                continue;
            }

            if (string.IsNullOrEmpty(keySetting.Text))
            {
                continue;
            }
            var bmp = CreateKeyBitmapFromText(keySetting.Text);
            streamDeck.SetKeyBitmap(bmp);
        }
    }

    private KeyBitmap CreateKeyBitmapFromText(
        string text,
        int keySize = 72,
        string fontName = "Arial",
        float fontSize = 18,
        Rgba32? textColor = null,
        Rgba32? bgColor = null)
    {
        textColor ??= Rgba32.ParseHex("000000");
        bgColor ??= Rgba32.ParseHex("FFFFFF");

        var fontCollection = new FontCollection();
        var font = fontCollection.AddSystemFonts().Get(fontName);
        var fontObj = new Font(font, fontSize, FontStyle.Bold);

        using var img = new Image<Rgba32>(keySize, keySize);
        img.Mutate(ctx =>
        {
            ctx.Clear(bgColor.Value);
            var textOptions = new RichTextOptions(fontObj)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Origin = new PointF(keySize / 2f, keySize / 2f),
                WrappingLength = keySize,
                
            };
            ctx.DrawText(textOptions, text, textColor.Value);
        });

        var pixelBytes = new byte[keySize * keySize * 4];
        img.CopyPixelDataTo(pixelBytes);

        return KeyBitmap.Create.FromRgba32Array(keySize, keySize, pixelBytes);
    }
}