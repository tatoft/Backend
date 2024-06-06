using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.IAM.Domain.Respositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync (string username);
    bool ExistsByUsername(string username);
}