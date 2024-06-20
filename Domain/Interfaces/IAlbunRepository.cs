using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAlbunRepository
    {
        IEnumerable<Albun> GetAllAlbun();
        Albun? GetAlbunById(int id);
        void AddAlbun(Albun albun);
        void UpdateAlbun(Albun albun);
        void DeleteAlbun(Albun albun);
    }
}
