using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.FederalUnit;
namespace Api.Domain.Interfaces.Services.FederalUnit
{
    public interface IFederalUnitService
    {
        Task<FederalUnitDto> Get(Guid id);
        Task<IEnumerable<FederalUnitDto>> GetAll();
    }
}