using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;

namespace StudyOn.Contracts.Commands
{
    public interface IAddUserCommand : ICommand<AddUserRequest, UserRegister>
    {
    }
}
