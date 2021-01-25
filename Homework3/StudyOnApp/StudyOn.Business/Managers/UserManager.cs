using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudyOn.Contracts;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace StudyOn.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<Users> _repository;
        private readonly IConfiguration _config;

        public UserManager(IRepository<Users> repository,
            IConfiguration config)
        {
            _repository = repository;
            _config = config;
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
                Password = EncodePassword(request.Password),
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

        public Response<LoggedInUserResponse> SignInUser(LoginRequest request)
        {
            var response = new Response<LoggedInUserResponse>();
            var encodedPassword = EncodePassword(request.Password);
            var user = _repository.Find(x=>x.UserName.Equals(request.UserName) && x.Password.Equals(encodedPassword)).FirstOrDefault();
            if(user!=null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response.Status = System.Net.HttpStatusCode.OK;
                var loggedInUser = new LoggedInUserResponse() { 
                    JWT = tokenString
                };
                response.Payload = loggedInUser;
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

        private string GenerateJSONWebToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(3600),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string EncodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public List<UserInfo> ToUserInfo(ICollection<UserMatches> userMatches)
        {
            var response = new List<UserInfo>();
            var userMatchesIds = userMatches.Select(x => x.UserId).ToList();
            userMatchesIds.ForEach(x =>
            {
                var user = _repository.Find(y => y.Id == x).FirstOrDefault();
                var userInfo = new UserInfo
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
                response.Add(userInfo);
            });
            return response;
        }
    }
}
