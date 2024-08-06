using Application.Common;
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
        private readonly IOperationResultService _operationResultService;
        public AlbunService(IAlbunRepository albunRepository,IUserRepository userRepository, IMapper mapper, IOperationResultService operationResultService)
        {
            _albunRepository = albunRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _operationResultService = operationResultService;
        }

        public AlbunDto? GetAlbunById(int id)
        {

            var albun = _albunRepository.GetAlbunById(id);
            return _mapper.Map<AlbunDto>(albun);
        }
        public IEnumerable<AlbunDto> GetAllAlbun()
        {
            var albun = _albunRepository.GetAllAlbun();
            return _mapper.Map<IEnumerable<AlbunDto>>(albun);
        }

        public OperationResult CreateAlbun(AlbunDto albunDto)
        {

            var user = _userRepository.GetUserById(albunDto.MusicianId);
            if (user == null)
            {
                return _operationResultService.CreateFailureResult("Musician not found.");
            }
            albunDto.MusicianName = user.UserName;
            if (!string.IsNullOrEmpty(albunDto.MusicianName))
            {
                var newAlbun = _mapper.Map<Albun>(albunDto);
                 _albunRepository.AddAlbun(newAlbun);
                return _operationResultService.CreateSuccessResult("Albun created successfully.");
            }
            else
            {
                return _operationResultService.CreateFailureResult("Musician Name cannot be empty.");
            }
        }
        public bool DeleteAlbun(int albunId)
        {
            var albunDelete = _albunRepository.GetAlbunById(albunId);
            if (albunDelete != null)
            {
                _albunRepository.DeleteAlbun(albunDelete);
                return true;
            }
            return false;
        }
        public OperationResult UpdateAlbun(int albunId ,AlbunDto albunDto)
        {
            var existAlbun = _albunRepository.GetAlbunById(albunId);
            if (existAlbun != null)
            {
                if (!string.IsNullOrEmpty(albunDto.MusicianName))
                {

                    existAlbun.Title = albunDto.Title;
                    existAlbun.Duration = albunDto.Duration;
                    existAlbun.MusicianId = albunDto.MusicianId;
                    existAlbun.MusicianName = albunDto.MusicianName;
                    existAlbun.Songs = albunDto.Songs;
                    _albunRepository.UpdateAlbun(existAlbun);
                    return _operationResultService.CreateSuccessResult("Albun Updated");
                }
                else
                {
                    return _operationResultService.CreateFailureResult("Musician Name cannot be empty.");
                }
            }
            else
            {
               return _operationResultService.CreateFailureResult("Albun not found");
            }
        }
    }
}
