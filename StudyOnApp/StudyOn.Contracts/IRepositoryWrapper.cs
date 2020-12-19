using StudyOn.Contracts.RepositoryUserClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts
{
    public interface IRepositoryWrapper
    {
        ICourtsRepository Courts { get; }
        IImagesRepository Images { get; }
        IMatchesRepository Matches { get; }
        IRatingsRepository Ratings { get; }
        IUsersRepository Users { get; }
        void Save();
    }
}
