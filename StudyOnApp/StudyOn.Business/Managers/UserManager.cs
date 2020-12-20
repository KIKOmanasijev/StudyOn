using StudyOn.Contracts;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using StudyOn.Data.Responses;
using System;
using System.Linq;

namespace StudyOn.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<Users> _repository;

        public UserManager(IRepository<Users> repository)
        {
            _repository = repository;
        }
        public Response<bool> AddUser(AddUserRequest request)
        {
            var response = new Response<bool>();
            Guid id = Guid.NewGuid();
            var newUser = new Users()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                Role = request.Role,
                Id = id.ToString()

            };
            try
            {
                _repository.Add(newUser);
                response.Status = System.Net.HttpStatusCode.OK;
                response.Payload = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = ex.Message,
                });
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }         
        }

        public Response<bool> SignInUser(LoginRequest request)
        {
            var response = new Response<bool>();

            var user = _repository.Find(x=>x.UserName.Equals(request.UserName) && x.Password.Equals(request.Password)).FirstOrDefault();
            if(user!=null)
            {
                response.Status = System.Net.HttpStatusCode.OK;
                response.Payload = true;
                return response;
            }
            else
            {
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = "The user does not exist",
                });
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }
    }
}
