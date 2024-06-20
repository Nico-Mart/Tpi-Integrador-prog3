using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class Repository : IRepository
    {
        internal readonly AlbunsContext _context;

        public Repository(AlbunsContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
