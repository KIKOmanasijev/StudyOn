using Court.Contracts;
using Court.Contracts.Managers;
using Court.Contracts.Models;
using Court.Contracts.Requests;
using Court.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Court.Business.Managers
{
    public class CourtsManager : ICourtsManager
    {
        private readonly IRepository<Courts> _repository;
        private readonly IRepository<Ratings> _ratingRepository;
        private readonly ILoggerManager _logger;

        public CourtsManager(IRepository<Courts> repository,
            IRepository<Ratings> ratingRepository,
            ILoggerManager logger)
        {
            _repository = repository;
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public Response<CourtDetails> GetCourt(GetCourtByIdRequest request)
        {
            var response = new Response<CourtDetails>();

            var sumRates = 0;
            var getCourt = _repository.Get<Courts>(includeProperties: $"{nameof(Ratings)}").Where(x => x.Id == request.CourtId).SingleOrDefault();
            var courtDetails = new CourtDetails()
            {
                Id = getCourt.Id,
                Lat = getCourt.Lat,
                Lng = getCourt.Lng,
                Name = getCourt.Name,
                Sport = getCourt.Sport
            };
            getCourt.Ratings.ToList().ForEach(x =>
            {
                sumRates += x.Rate;
            });

            if (sumRates == 0)
            {
                courtDetails.AverageRating = 0;
            } else
            {
                courtDetails.AverageRating = sumRates / getCourt.Ratings.Count();
            }           
            _logger.LogInfo("court details returned");
            response.Payload = courtDetails;
            return response;

        }

        public Response<List<UserRatings>> GetCourtRatings(GetCourtByIdRequest request)
        {
            var response = new Response<List<UserRatings>>();
            var pagedResponse = new List<UserRatings>();
            var getRatings = _ratingRepository.GetAll<Ratings>(includeProperties: $"{nameof(Ratings.User)}").Where(x => x.CourtId == request.CourtId).ToList();
            if (getRatings == null)
            {
                _logger.LogError("no ratings found");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Exception,
                    Message = "the court does not exist",
                });
                response.Status = System.Net.HttpStatusCode.NotFound;
            }
            getRatings.ForEach(x =>
            {
                var userRating = new UserRatings()
                {
                    Email = x.User.Email,
                    UserName = x.User.UserName,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Id = x.User.Id,
                    Comment = x.Comment,
                    Rate = x.Rate
                };
                pagedResponse.Add(userRating);
            });

            _logger.LogInfo("user ratings returned");
            response.Payload = pagedResponse;
            response.Status = System.Net.HttpStatusCode.OK;
            return response;
        }

        public Response<List<Courts>> GetCourts(GetCourtsRequest request)
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
            if (pagedResponse == null)
            {
                _logger.LogInfo("there are no courts with this search criteria");
                response.Messages.Add(new ResponseMessage
                {
                    Type = Contracts.Enums.ResponseMessageEnum.Info,
                    Message = "There are no courts with this search criteria",
                });
                response.Status = System.Net.HttpStatusCode.NotFound;
            }
            _logger.LogInfo("list of courts returned");
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
                _logger.LogInfo("user rated a court");
                response.Status = System.Net.HttpStatusCode.OK;
                response.Payload = true;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("rating of court failed");
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
