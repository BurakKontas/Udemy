using Udemy.User.Domain.Entities.User.Enums;

namespace Udemy.User.Domain.Entities.User.ValueObjects;

public class IdentityProvider
{
    public IdentityProviderType Provider { get; private set; }
    public string ProviderId { get; private set; }

    public IdentityProvider(IdentityProviderType provider, string providerId)
    {

        if (string.IsNullOrWhiteSpace(providerId))
            throw new ArgumentException("Provider ID cannot be empty.", nameof(providerId));

        Provider = provider;
        ProviderId = providerId;
    }
}
