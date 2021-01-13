using Court.Contracts;
using Court.Contracts.Managers;
using Court.Contracts.Models;
using Court.Contracts.Requests;
using Court.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Court.Business.Managers
{
    public class CourtsManager : ICourtsManager
    {
        private readonly IRepository<Courts> _repository;
        private readonly IRepository<Ratings> _ratingRepository;

        public CourtsManager(IRepository<Courts> repository,
            IRepository<Ratings> ratingRepository)
        {
            _repository = repository;
            _ratingRepository = ratingRepository;
        }
        public Response<List<Courts>> GetCourt(GetCourtsRequest request)
        {
            var response = new Response<List<Courts>>();
            var pagedResponse = new List<Courts>();
            if (!string.IsNullOrEmpty(request.Type) && !string.IsNullOrEmpty(request.Name))
            {
                var getCourts = _repository.GetAll<Courts>().Where(x => x.Sport.Equals(request.Type) && x.Name.Equals(request.Name));
                pagedResponse = getCourts
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(request.Name))
            {
                var getCourts = _repository.GetAll<Courts>().Where(x => x.Name.Equals(request.Name));
                pagedResponse = getCourts
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(request.Type))
            {
                var getCourts = _repository.GetAll<Courts>().Where(x => x.Sport.Equals(request.Type));
                pagedResponse = getCourts
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }
            else
            {
                var getCourts = _repository.GetAll<Courts>();
                pagedResponse = getCourts
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }

            response.Payload = pagedResponse;
            return response;
        }

        public Response<bool> ReviewCourt(ReviewCourtRequest request)
        {
            var response = new Response<bool>();
            Guid id = Guid.NewGuid();
            var newRate = new Ratings()
            {
                UserId = request.UserId,
                CourtId = request.CourtId,
                Rate = request.Rate,
                Comment = request.Comment,
                Id = id.ToString()
            };
            try
            {
                _ratingRepository.Add(newRate);
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
