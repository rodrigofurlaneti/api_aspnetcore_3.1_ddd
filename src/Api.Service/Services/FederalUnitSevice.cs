using Api.Domain.Repository;
using Api.Domain.Interfaces.Services.FederalUnit;
using Api.Domain.Dtos.FederalUnit;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Api.Domain.Entities;
namespace Api.Service.Services
{
    public class FederalUnitService : IFederalUnitService
    {
        private IFederalUnitRepository _federalUnitRepository;
        private readonly IMapper _iMapper;
        public FederalUnitService(IFederalUnitRepository federalUnitRepository, IMapper iMapper)
        {
            _federalUnitRepository = federalUnitRepository;
            _iMapper = iMapper;
        }
        public async Task<FederalUnitDto> Get(Guid id)
        {
            FederalUnitEntity federalUnitEntity = await _federalUnitRepository.SelectAsync(id);
            return _iMapper.Map<FederalUnitDto>(federalUnitEntity);
        }
        public async Task<IEnumerable<FederalUnitDto>> GetAll()
        {
            var listFederalUnitEntity = await _federalUnitRepository.SelectAsync();
            return _iMapper.Map<IEnumerable<FederalUnitDto>>(listFederalUnitEntity);
        }
    }
}