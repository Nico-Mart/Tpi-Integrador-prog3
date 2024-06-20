using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AlbunService : IAlbunService
    {
        private readonly IAlbunRepository _albunRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AlbunService(IAlbunRepository albunRepository,IUserRepository userRepository, IMapper mapper)
        {
            _albunRepository = albunRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Albun? GetAlbunById(int id)
        {
            return _albunRepository.GetAlbunById(id);
        }
        public IEnumerable<Albun> GetAllAlbun()
        {
            return _albunRepository.GetAllAlbun();
        }

        public void CreateAlbun(AlbunDto albunDto)
        {

            var user = _userRepository.GetUserById(albunDto.MusicianId);
            albunDto.MusicianName = user.UserName;
            if (!string.IsNullOrEmpty(albunDto.MusicianName))
            {
                var newAlbun = _mapper.Map<Albun>(albunDto);
                _albunRepository.AddAlbun(newAlbun);
            }
            else
            {
                throw new InvalidOperationException("Musician Name cannot be empty.");
            }
        }

        public void DeleteAlbun(int albunId)
        {
            var albunDelete = _mapper.Map<Albun>(albunId);
            _albunRepository.DeleteAlbun(albunDelete);
        }

        public void UpdateAlbun(int albunId ,AlbunDto albunDto)
        {
            var existAlbun = _albunRepository.GetAlbunById(albunId);
            if (existAlbun != null)
            {
                existAlbun.Title = albunDto.Title;
                existAlbun.Duration = albunDto.Duration;
                existAlbun.MusicianId = albunDto.MusicianId;
                existAlbun.MusicianName = albunDto.MusicianName;
                existAlbun.Songs = albunDto.Songs;
            }
            else
            {
                throw new InvalidOperationException("Albun not found");
            }
            _albunRepository.UpdateAlbun(existAlbun);
        }
    }
}
