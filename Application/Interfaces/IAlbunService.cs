using Application.Common;
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
        IEnumerable<AlbunDto> GetAllAlbun();
        AlbunDto? GetAlbunById(int id);
        OperationResult CreateAlbun(AlbunDto albunDto);
        OperationResult UpdateAlbun(int albunId,AlbunDto albunDto);
        bool DeleteAlbun(int albunId);
    }
}
