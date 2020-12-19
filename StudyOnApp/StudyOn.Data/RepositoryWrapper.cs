using StudyOn.Contracts;
using StudyOn.Contracts.RepositoryUserClasses;
using StudyOn.Data.RepositoryUserClasses;

namespace StudyOn.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private postgresContext _repoContext;
        private ICourtsRepository _courts;
        private IImagesRepository _images;
        private IMatchesRepository _matches;
        private IRatingsRepository _ratings;
        private IUsersRepository _users;
        public ICourtsRepository Courts
        {
            get
            {
                if (_courts == null)
                {
                    _courts = new CourtsRepository(_repoContext);
                }
                return _courts;
            }
        }
        public IImagesRepository Images
        {
            get
            {
                if (_images == null)
                {
                    _images = new ImagesRepository(_repoContext);
                }
                return _images;
            }
        }
        public IMatchesRepository Matches
        {
            get
            {
                if (_matches == null)
                {
                    _matches = new MatchesRepository(_repoContext);
                }
                return _matches;
            }
        }
        public IRatingsRepository Ratings
        {
            get
            {
                if (_ratings == null)
                {
                    _ratings = new RatingsRepository(_repoContext);
                }
                return _ratings;
            }
        }
        public IUsersRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UsersRepository(_repoContext);
                }
                return _users;
            }
        }
        public RepositoryWrapper(postgresContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
