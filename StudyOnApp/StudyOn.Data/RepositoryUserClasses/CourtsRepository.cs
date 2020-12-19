﻿using StudyOn.Contracts;
using StudyOn.Contracts.RepositoryUserClasses;

namespace StudyOn.Data.RepositoryUserClasses
{
    class CourtsRepository : RepositoryBase<Courts>, ICourtsRepository
    {
        public CourtsRepository(postgresContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}