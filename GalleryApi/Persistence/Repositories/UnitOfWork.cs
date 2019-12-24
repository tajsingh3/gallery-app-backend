using System;
using System.Threading.Tasks;
using GalleryApi.Domain.Repositories;
using GalleryApi.Persistence.Contexts;

namespace GalleryApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
