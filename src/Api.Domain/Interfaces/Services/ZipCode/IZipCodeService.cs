using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;
namespace Api.Domain.Interfaces.Services.ZipCode
{
    public interface IZipCodeService
    {
         Task<ZipCodeDto> Get(Guid id);
        Task<ZipCodeDto> Get(string zipCode);
        Task<ZipCodeCreateResultDto> Post(ZipCodeCreateDto zipCodeCreateDto);
        Task<ZipCodeUpdateResultDto> Put(ZipCodeUpdateDto zipCodeUpdateDto);
        Task<bool> Delete(Guid id);
    }
}