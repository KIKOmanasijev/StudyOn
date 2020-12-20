﻿using StudyOn.Contracts.Models;
using StudyOn.Contracts.RepositoryUserClasses;

namespace StudyOn.Data.RepositoryUserClasses
{
    public class RatingsRepository : RepositoryBase<Ratings>, IRatingsRepository
    {
        public RatingsRepository(postgresContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}