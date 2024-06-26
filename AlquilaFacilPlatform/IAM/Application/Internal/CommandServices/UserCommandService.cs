using AlquilaFacilPlatform.IAM.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Model.Commands;
using AlquilaFacilPlatform.IAM.Domain.Respositories;
using AlquilaFacilPlatform.IAM.Domain.Services;
using AlquilaFacilPlatform.IAM.Infrastructure.Hashing.BCrypt.Services;
using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Profiles.Domain.Repositories;
using AlquilaFacilPlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.IAM.Application.Internal.CommandServices;

public class UserCommandService (
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork, IProfileRepository profileRepository)
    : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        
        User.GlobalVariables.UserId = user.Id;
        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
    public async Task<User?> Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");

        List<Profile> profiles = await profileRepository.GetProfilesByDocumentNumber(command.DocumentNumber);
        if(profiles.Any())
            throw new Exception($"Document number {command.DocumentNumber} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync(); // Save the user first
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }

        var profile = new Profile(command.Name, command.FatherName, command.MotherName, command.DateOfBirth, command.DocumentNumber, command.Phone);
        profile.setUserId(user.Id); // Set the user id after the user has been saved
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync(); // Save the profile
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating profile: {e.Message}");
        }

        return user;
    }
}