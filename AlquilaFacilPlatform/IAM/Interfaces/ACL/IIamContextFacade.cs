namespace AlquilaFacilPlatform.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, string Name, string FatherName, string MotherName, string DateOfBirth, string DocumentNumber,
        string Phone);
    Task<int> FetchUserIdByUsername(string username);
    Task<string> FetchUsernameByUserId(int userId);
}