using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Data.Responses;

namespace StudyOn.Contracts
{
    public interface IUserManager
    {
        Response<UserRegister> AddUser(AddUserRequest request);
    }
}
