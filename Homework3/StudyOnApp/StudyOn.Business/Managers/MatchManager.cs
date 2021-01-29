using StudyOn.Contracts;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyOn.Business.Managers
{
    public class MatchManager : IMatchManager
    {
        private readonly IRepository<Matches> _repository;
        private readonly IRepository<UserMatches> _umRepository;
        private readonly ILoggerManager _logger;

        public MatchManager(IRepository<Matches> repository,
            IRepository<UserMatches> umRepository,
            IUserManager userManager,
            IRepository<Courts> courtsRepository,
            ILoggerManager logger)
        {
            _repository = repository;
            _umRepository = umRepository;
            _logger = logger;
        }
        public Response<bool> AddMatch([FromBody] AddMatchRequest request)
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
                _logger.LogInfo("new match created");
                return AddUserMatch(request.UserId, result.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("match creation failed");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = ex.Message,
                });
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        public Response<List<Matches>> GetMatches(GetMatchesRequest request)
        {
            var response = new Response<List<Matches>>();
            var pagedResponse = new List<Matches>();
            if (!string.IsNullOrEmpty(request.Type))
            {
                var getMatches = _repository.GetAll<Matches>().Where(x => x.Type.Equals(request.Type));
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
            if (pagedResponse == null)
            {
                _logger.LogInfo("there are no matches with this search criteria");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Info,
                    Message = "There are no matches with this search criteria",
                });
                response.Status = System.Net.HttpStatusCode.NotFound;
            }
            _logger.LogInfo("list of matches returned");
            response.Payload = pagedResponse;
            return response;

        }
        public Response<bool> JoinMatch(JoinMatchRequest request)
        {
            return AddUserMatch(request.UserId, request.MatchId);
        }
        public Response<bool> AddUserMatch(string userId, string matchId)
        {
            var response = new Response<bool>();
            Guid id = Guid.NewGuid();

            var userMatch = new UserMatches
            {
                UserId = userId,
                MatchId = matchId,
                Id = id.ToString()
            };
            try
            {
                var result = _umRepository.Add(userMatch);
                var updateMatch = _repository.Find(x => x.Id == matchId).FirstOrDefault();
                updateMatch.CurrentPlayers++;
                _repository.Update(updateMatch);
                _logger.LogInfo("new player added to match");
                response.Payload = true;
                response.Status = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError("join player to match failed");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = ex.Message,
                });
                response.Status = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public Response<MatchDetails> GetMatch(GeMatchByIdRequest request)
        {
            var response = new Response<MatchDetails>();
            var getMatch = _repository.GetOne<Matches>(x => x.Id == request.MatchId, includeProperties: $"{nameof(Matches.UserMatches)},{nameof(Matches.Court)}");
            if (getMatch == null)
            {
                _logger.LogError("no match found");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = "the match does not exist",
                });
                response.Status = System.Net.HttpStatusCode.NotFound;
            }

            var matchDetails = new MatchDetails()
            {
                MatchId = getMatch.Id,
                CourtName = getMatch.Court.Name,
                Lat = getMatch.Court.Lat,
                Lng = getMatch.Court.Lng,
                MaxPlayers = getMatch.MaxPlayers,
                CurrentPlayers = getMatch.CurrentPlayers,
                Type = getMatch.Type,
                StartTime = getMatch.StartTime,
                EndTime = getMatch.EndTime,

            };
            _logger.LogInfo("match details returned");

            response.Payload = matchDetails;
            response.Status = System.Net.HttpStatusCode.OK;

            return response;
        }

        public Response<List<UserInfo>> GetMatchPlayers(GeMatchByIdRequest request)
        {
            var response = new Response<List<UserInfo>>();
            var pagedResponse = new List<UserInfo>();
            var getPlayers = _umRepository.GetAll<UserMatches>(includeProperties: $"{nameof(UserMatches.User)}").Where(x => x.MatchId == request.MatchId).ToList();
            if (getPlayers == null)
            {
                _logger.LogError("no players found");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = "the match does not exist",
                });
                response.Status = System.Net.HttpStatusCode.NotFound;
            }
            getPlayers.ForEach(x =>
            {
               var playerInfo = new UserInfo()
               {
                   Email = x.User.Email,
                   UserName = x.User.UserName,
                   FirstName = x.User.FirstName,
                   LastName = x.User.LastName,
                   Id = x.User.Id
               };
                pagedResponse.Add(playerInfo);
            });

            _logger.LogInfo("player details returned");
            response.Payload = pagedResponse;
            response.Status = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}