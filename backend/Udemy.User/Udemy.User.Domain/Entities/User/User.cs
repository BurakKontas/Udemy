using Udemy.User.Domain.Entities.User.Enums;
using Udemy.User.Domain.Entities.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using Udemy.Common.Result;

namespace Udemy.User.Domain.Entities.User;

public class User
{
    public Guid Id { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password PasswordHash { get; private set; }
    public Url AvatarUrl { get; private set; }
    public Role Role { get; private set; }
    public string Biography { get; private set; }
    public ICollection<SocialMedia> SocialMedias { get; private set; } = new List<SocialMedia>();
    public ICollection<IdentityProvider> IdentityProviders { get; private set; } = new List<IdentityProvider>();

    // Private constructor to ensure the object is created through the Create method
    private User(Name name, Email email, Password passwordHash, Url avatarUrl, string biography)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = Role;
        AvatarUrl = avatarUrl;
        Biography = biography;
    }

    public static Result<User> Create(string name, string email, string password, string avatarUrl, string biography)
    {
        var nameResult = Name.Create(name);
        if (nameResult.IsFailure) return Result<User>.Failure(nameResult.Message);

        var emailResult = Email.Create(email);
        if (emailResult.IsFailure) return Result<User>.Failure(emailResult.Message);

        var passwordResult = Password.Create(password);
        if (passwordResult.IsFailure) return Result<User>.Failure(passwordResult.Message);

        var avatarResult = Url.Create(avatarUrl);
        if (avatarResult.IsFailure) return Result<User>.Failure(avatarResult.Message);

        var newUser = new User(nameResult.Value, emailResult.Value, passwordResult.Value, avatarResult.Value, biography);
        return Result<User>.Success(newUser, "User created successfully.");
    }

    // Update methods return Result instead of throwing exceptions
    public Result UpdateName(string newName)
    {
        var nameResult = Name.Create(newName);
        if (nameResult.IsFailure) return Result.Failure(nameResult.Message);

        Name = nameResult.Value;
        return Result.Success("Name updated successfully.");
    }

    public Result UpdateEmail(string newEmail)
    {
        var emailResult = Email.Create(newEmail);
        if (emailResult.IsFailure) return Result.Failure(emailResult.Message);

        Email = emailResult.Value;
        return Result.Success("Email updated successfully.");
    }

    public Result UpdateAvatar(Url newAvatarUrl)
    {
        AvatarUrl = newAvatarUrl;
        return Result.Success("Avatar updated successfully.");
    }

    public void UpdateBiography(string biography)
    {
        Biography = biography;
    }

    public Result AddSocialMedia(SocialMedia socialMedia)
    {
        var hasMedia = SocialMedias.Any(x => x.Media == socialMedia.Media);
        if (hasMedia)
            return Result.Failure("Social media already exists.");

        SocialMedias.Add(socialMedia);
        return Result.Success("Social media added successfully.");
    }

    public Result ChangePassword(string newPassword)
    {
        var passwordResult = Password.Create(newPassword);
        if (passwordResult.IsFailure) return Result.Failure(passwordResult.Message);

        PasswordHash = passwordResult.Value;
        return Result.Success("Password changed successfully.");
    }

    public void AssignRole(Role newRole)
    {
        Role = newRole;
    }

    public Result AddIdentityProvider(IdentityProvider newIdentityProvider)
    {
        if (IdentityProviders.Any(x => x.Provider == newIdentityProvider.Provider))
            return Result.Failure("Identity provider already exists.");

        IdentityProviders.Add(newIdentityProvider);
        return Result.Success("Identity provider added successfully.");
    }
}