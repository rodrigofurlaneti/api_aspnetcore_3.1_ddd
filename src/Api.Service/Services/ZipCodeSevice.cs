using Api.Domain.Repository;
using Api.Domain.Interfaces.Services.ZipCode;
using Api.Domain.Dtos.ZipCode;
using AutoMapper;
using System.Threading.Tasks;
using System;
using Api.Domain.Entities;
using Api.Domain.Models;
namespace Api.Service.Services
{
    public class ZipCodeService : IZipCodeService
    {
        private IZipCodeRepository _zipCodeRepository;
        private readonly IMapper _iMapper;
        public ZipCodeService(IZipCodeRepository ZipCodeRepository, IMapper iMapper)
        {
            _zipCodeRepository = ZipCodeRepository;
            _iMapper = iMapper;
        }
        public async Task<ZipCodeDto> Get(Guid id)
        {
            var zipCodeEntity = await _zipCodeRepository.SelectAsync(id);
            return _iMapper.Map<ZipCodeDto>(zipCodeEntity);
        }
        public async Task<ZipCodeDto> Get(string zipCode)
        {
            var zipCodeEntity = await _zipCodeRepository.SelectAsync(zipCode);
            return _iMapper.Map<ZipCodeDto>(zipCodeEntity);
        }
        public async Task<ZipCodeCreateResultDto> Post(ZipCodeCreateDto zipCodeCreateDto)
        {
            var zipCodeModel = _iMapper.Map<ZipCodeModel>(zipCodeCreateDto);
            var zipCodeEntity = _iMapper.Map<ZipCodeEntity>(zipCodeModel);
            var result = await _zipCodeRepository.InsertAsync(zipCodeEntity);
            return _iMapper.Map<ZipCodeCreateResultDto>(result);
        }
        public async Task<ZipCodeUpdateResultDto> Put(ZipCodeUpdateDto zipCodeUpdateDto)
        {
            var zipCodeModel = _iMapper.Map<ZipCodeModel>(zipCodeUpdateDto);
            var zipCodeEntity = _iMapper.Map<ZipCodeEntity>(zipCodeModel);
            var result = await _zipCodeRepository.UpdateAsync(zipCodeEntity);
            return _iMapper.Map<ZipCodeUpdateResultDto>(result);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _zipCodeRepository.DeleteAsync(id);
        }
    }
}