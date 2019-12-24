using System;
using System.Threading.Tasks;

namespace GalleryApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task CompleteAsync();
    }
}
