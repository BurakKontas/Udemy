using Udemy.User.Domain.Entities.User.Enums;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class SocialMedia(SocialMediaType media, Uri uri)
{
    public SocialMediaType Media { get; private set; } = media;
    public Uri Uri { get; private set; } = uri ?? throw new ArgumentNullException(nameof(uri));

    public void ChangeUri(Uri uri)
    {
        Uri = uri;
    }
}
