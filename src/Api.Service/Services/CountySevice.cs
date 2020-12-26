using Api.Domain.Repository;
using Api.Domain.Interfaces.Services.County;
using Api.Domain.Dtos.County;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Models;
namespace Api.Service.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository _countyRepository;
        private readonly IMapper _iMapper;
        public CountyService(ICountyRepository countyRepository, IMapper iMapper)
        {
            _countyRepository = countyRepository;
            _iMapper = iMapper;
        }
        public async Task<CountyDto> Get(Guid id)
        {
            var countyEntity = await _countyRepository.SelectAsync(id);
            return _iMapper.Map<CountyDto>(countyEntity);
        }
        public async Task<CountyCompleteDto> GetCompleteById(Guid id)
        {
            var countyEntity = await _countyRepository.GetCompleteByIdAsync(id);
            return _iMapper.Map<CountyCompleteDto>(countyEntity);
        }
        public async Task<CountyCompleteDto> GetCompleteByIbge(int codeIbge)
        {
            var countyEntity = await _countyRepository.GetCompleteByIbgeAsync(codeIbge);
            return _iMapper.Map<CountyCompleteDto>(countyEntity);
        }
        public async Task<IEnumerable<CountyDto>> GetAll()
        {
            var countyEntity = await _countyRepository.SelectAsync();
            return _iMapper.Map<IEnumerable<CountyDto>>(countyEntity);
        }
        public async Task<CountyCreateResultDto> Post(CountyCreateDto countyCreateDto)
        {
            var modelCounty = _iMapper.Map<CountyModel>(countyCreateDto);
            var entityCounty = _iMapper.Map<CountyEntity>(modelCounty);
            var resultCounty = await _countyRepository.InsertAsync(entityCounty);
            return _iMapper.Map<CountyCreateResultDto>(resultCounty);
        }
        public async  Task<CountyUpdateResultDto> Put(CountyUpdateDto countyUpdateDto)
        {
            var modelCounty = _iMapper.Map<CountyModel>(countyUpdateDto);
            var entityCounty = _iMapper.Map<CountyEntity>(modelCounty);
            var resultCounty = await _countyRepository.UpdateAsync(entityCounty);
            return _iMapper.Map<CountyUpdateResultDto>(resultCounty);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _countyRepository.DeleteAsync(id);
        }
    }
}