using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AlbunRepository : Repository, IAlbunRepository
    {
        public AlbunRepository(AlbunsContext context) : base(context)
        { 
        }
        public void AddAlbun(Albun albun)
        {
            _context.Add(albun);
            SaveChanges();
        }

        public void DeleteAlbun(Albun albun)
        {
            _context.Remove(albun);
            SaveChanges();
        }

        public IEnumerable<Albun> GetAllAlbun()
        {
            return _context.Albuns;
        }

        public Albun? GetAlbunById(int albunId)
        {
            return _context.Albuns.Find(albunId);
        }

        public void UpdateAlbun(Albun albun)
        {
            _context.Albuns.Update(albun);
            SaveChanges();
        }
    }
}
