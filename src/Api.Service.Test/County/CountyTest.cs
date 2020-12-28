using System;
using System.Collections.Generic;
using Api.Domain.Dtos.County;
using Api.Domain.Dtos.FederalUnit;

namespace Api.Service.Test.County
{
    public class CountyTest
    {
        public static string NameCounty{ get; set;}
        public static int CodeIbgeCounty{ get; set;}
        public static string NameUpdate{ get; set;}
        public static int CodeIbgeUpdate{ get; set;}
        public static Guid IdCounty{ get; set;}
        public static Guid FederalUnitId;
        public List<CountyDto> listCountyDto = new List<CountyDto>();
        public CountyDto countyDto;
        public CountyCompleteDto countyCompleteDto;
        public CountyCreateDto countyCreateDto;
        public CountyCreateResultDto countyCreateResultDto;
        public CountyUpdateDto countyUpdateDto;
        public CountyUpdateResultDto countyUpdateResultDto;
        public CountyTest()
        {   
            IdCounty = Guid.NewGuid();
            NameCounty = Faker.Address.StreetName();
            CodeIbgeCounty = Faker.RandomNumber.Next(1,10000);
            NameUpdate = Faker.Address.StreetName();
            CodeIbgeUpdate = Faker.RandomNumber.Next(1,10000);
            FederalUnitId = Guid.NewGuid();
            for(int i = 0; i < 10; i++)
            {
                var dto = new CountyDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CodeIbge = Faker.RandomNumber.Next(1,10000),
                    FederalUnitId = Guid.NewGuid()
                };
                listCountyDto.Add(dto);
            }
            countyDto = new CountyDto
            { 
                Id = IdCounty,
                Name = NameCounty,
                CodeIbge = CodeIbgeCounty,
                FederalUnitId = FederalUnitId
            };
            countyCompleteDto = new CountyCompleteDto
            { 
                Id = IdCounty,
                Name = NameCounty,
                CodeIbge = CodeIbgeCounty,
                FederalUnitId = FederalUnitId,
                FederalUnit = new FederalUnitDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initials = Faker.Address.UsState().Substring(1, 3)
                }
            };
            countyCreateDto = new CountyCreateDto
            {
                Name = NameCounty,
                CodeIbge = CodeIbgeCounty,
                FederalUnitId = FederalUnitId
            };
            countyCreateResultDto = new CountyCreateResultDto
            {
                Id = IdCounty,
                Name = NameCounty,
                CodeIbge = CodeIbgeCounty,
                FederalUnitId = FederalUnitId,
                CreateAt = DateTime.Now
            };
            countyUpdateDto = new CountyUpdateDto
            {
                Id = IdCounty,
                Name = NameUpdate,
                CodeIbge = CodeIbgeUpdate, 
                FederalUnitId = FederalUnitId
            };
            countyUpdateResultDto = new CountyUpdateResultDto
            {
                Id = IdCounty,
                Name = NameUpdate,
                CodeIbge = CodeIbgeUpdate, 
                FederalUnitId = FederalUnitId,
                UpdateAt = DateTime.Now
            };
         }
    }
}