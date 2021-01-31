using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System.Collections.Generic;

namespace StudyOn.Contracts
{
    public interface IUserManager
    {
        Response<bool> AddUser(AddUserRequest request);
        Response<LoggedInUserResponse> SignInUser(LoginRequest request);
    }
}
