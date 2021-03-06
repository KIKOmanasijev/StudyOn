﻿using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System.Collections.Generic;

namespace StudyOn.Contracts.Managers
{
    public interface IMatchManager
    {
        Response<bool> AddMatch(AddMatchRequest request);
        Response<bool> JoinMatch(JoinMatchRequest request);
        Response<List<Matches>> GetMatches(GetMatchesRequest request);
        Response<MatchDetails> GetMatch(GeMatchByIdRequest request);
        Response<List<UserInfo>> GetMatchPlayers(GeMatchByIdRequest request);
    }
}
