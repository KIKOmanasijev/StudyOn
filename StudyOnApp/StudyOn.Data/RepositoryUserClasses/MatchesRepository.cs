using StudyOn.Contracts.Models;
using StudyOn.Contracts.RepositoryUserClasses;

namespace StudyOn.Data.RepositoryUserClasses
{
    public class MatchesRepository : RepositoryBase<Matches>, IMatchesRepository
    {
        public MatchesRepository(postgresContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
