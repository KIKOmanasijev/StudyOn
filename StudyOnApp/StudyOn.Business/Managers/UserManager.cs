using StudyOn.Contracts;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using StudyOn.Data.Responses;
using System;

namespace StudyOn.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IRepositoryWrapper _repository;

        public UserManager(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public Response<bool> AddUser(AddUserRequest request)
        {
            var response = new Response<bool>();
            var newUser = new Users()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                Role = request.Role,

            };
            try
            {
                _repository.Users.Create(newUser);
                _repository.Save();
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
    }
}
