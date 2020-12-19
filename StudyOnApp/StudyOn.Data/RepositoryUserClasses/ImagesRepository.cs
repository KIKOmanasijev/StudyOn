
using StudyOn.Contracts;
using StudyOn.Contracts.RepositoryUserClasses;

namespace StudyOn.Data.RepositoryUserClasses
{
    class ImagesRepository : RepositoryBase<Images>, IImagesRepository
    {
        public ImagesRepository(postgresContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
