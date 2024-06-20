using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAlbunService
    {
        IEnumerable<Albun> GetAllAlbun();
        Albun? GetAlbunById(int id);
        void CreateAlbun(AlbunDto albunDto);
        void UpdateAlbun(int albunId,AlbunDto albunDto);
        void DeleteAlbun(int albunId);
    }
}
