using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using StudyOn.Data;
using StudyOn.Data.Responses;
using System;

namespace StudyOn.Business.Managers
{
    public class MatchManager : IMatchManager
    {
        private readonly Repository<Matches> _repository;

        public MatchManager(Repository<Matches> repository)
        {
            _repository = repository;
        }
        public Response<bool> AddMatch(AddMatchRequest request)
        {
            var response = new Response<bool>();

            Guid id = Guid.NewGuid();
            var match = new Matches
            {
                CourtId = request.CourtId,
                MaxPlayers = request.MaxPlayers,
                Date = request.Date,
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                Type = request.Type,
                Id = id.ToString()
            };
            try
            {
                _repository.Add(match);
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
