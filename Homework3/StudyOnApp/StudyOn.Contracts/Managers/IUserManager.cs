using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;

namespace StudyOn.Contracts
{
    public interface IUserManager
    {
        Response<bool> AddUser(AddUserRequest request);
        Response<LoggedInUserResponse> SignInUser(LoginRequest request);
    }
}
