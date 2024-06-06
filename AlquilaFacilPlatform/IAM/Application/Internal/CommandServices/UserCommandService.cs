using AlquilaFacilPlatform.IAM.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Model.Commands;
using AlquilaFacilPlatform.IAM.Domain.Respositories;
using AlquilaFacilPlatform.IAM.Domain.Services;
using AlquilaFacilPlatform.IAM.Infraestructure.Hashing.BCrypt.Services;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.IAM.Application.Internal.CommandServices;

public class UserCommandService (
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
    ) : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
        {
            throw new Exception("Invalid credentials");
        }
        
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
        {
            throw new Exception("Username already exists");
        }
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }
}