using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
namespace Api.Domain.Interfaces.Services.County
{
    public interface ICountyService
    {
        Task<CountyDto> Get(Guid id);
        Task<CountyCompleteDto> GetCompleteById(Guid id);
        Task<CountyCompleteDto> GetCompleteByIbge(int codeIbge);
        Task<IEnumerable<CountyDto>> GetAll();
        Task<CountyCreateResultDto> Post(CountyCreateDto countyCreateDto);
        Task<CountyUpdateResultDto> Put(CountyUpdateDto countyUpdateDto);
        Task<bool> Delete(Guid id);
    }
}