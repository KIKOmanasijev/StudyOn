using StudyOn.Contracts;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyOn.Business.Managers
{
    public class MatchManager : IMatchManager
    {
        private readonly IRepository<Matches> _repository;
        private readonly IRepository<UserMatches> _umRepository;

        public MatchManager(IRepository<Matches> repository,
            IRepository<UserMatches> umRepository)
        {
            _repository = repository;
            _umRepository = umRepository;
        }
        public Response<bool> AddMatch(AddMatchRequest request)
        {
            var response = new Response<bool>();

            Guid id = Guid.NewGuid();
            var match = new Matches
            {
                CourtId = Decimal.Parse(request.CourtId),
                MaxPlayers = request.MaxPlayers,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Type = request.Type,
                Id = id.ToString(),
            };
            try
            {
                var result = _repository.Add(match);
                return AddUserMatch(request.UserId, result.Id);
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

        public Response<bool> JoinMatch(JoinMatchRequest request)
        {
            return AddUserMatch(request.userId, request.matchId);
        }

        public Response<List<Matches>> GetMatch(GetMatchesRequest request)
        {
            var response = new Response<List<Matches>>();
            var pagedResponse = new List<Matches>();
            if (!string.IsNullOrEmpty(request.Type))
            {
                var getMatches = _repository.GetAll<Matches>().Where(x=>x.Type.Equals(request.Type));
                pagedResponse = getMatches.OrderByDescending(x => x.CurrentPlayers)
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }
            else
            {
                var getMatches = _repository.GetAll<Matches>();
                pagedResponse = getMatches.OrderByDescending(x => x.CurrentPlayers)
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
            }

            response.Payload = pagedResponse;
            return response;

        }
        public Response<bool> AddUserMatch (string userId,string matchId)
        {
            var response = new Response<bool>();
            var userMatch = new UserMatches
            {
                UserId = userId,
                MatchId = matchId
            };
            try
            {
                var result = _umRepository.Add(userMatch);
                response.Payload = true;
                response.Status = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = ex.Message,
                });
                response.Status = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }


    }
}
