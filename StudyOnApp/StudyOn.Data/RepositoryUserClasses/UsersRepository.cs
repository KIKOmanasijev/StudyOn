using StudyOn.Contracts.Models;
using StudyOn.Contracts.RepositoryUserClasses;

namespace StudyOn.Data.RepositoryUserClasses
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        public UsersRepository(postgresContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
