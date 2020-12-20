﻿using StudyOn.Contracts;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using StudyOn.Data.Responses;
using System;

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