using AlquilaFacilPlatform.IAM.Domain.Respositories;
using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Profiles.Domain.Model.Commands;
using AlquilaFacilPlatform.Profiles.Domain.Repositories;
using AlquilaFacilPlatform.Profiles.Domain.Services;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command.Name, command.FatherName, command.MotherName, command.DateOfBirth, 
            command.DocumentNumber, command.Phone, command.UserId);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            var user = await userRepository.FindByIdAsync(command.UserId);
            profile.User = user;
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }

    public async Task<Profile> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.UserId);
        if (profile == null)
        {
            throw new Exception("Profile with ID does not exist");
        }

        profile.Update(command);
        await unitOfWork.CompleteAsync();
        return profile;
    }
}