using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.County;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Service.Test.Base;
using Xunit;
namespace Api.Service.Test.AutoMapper
{
    public class CountyMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os modelo County")]
        public void ItIsPossibleToMapTheModelsCounty()
        {
            var countyModel = new CountyModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodeIbge = Faker.RandomNumber.Next(1000000, 9999999),
                FederalUnitId = Guid.NewGuid(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
            var listCountyEntity = new List<CountyEntity>();
            for(int i = 0; i < 5; i++)
            {
                var itemCountyEntity = new CountyEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.City(),
                    CodeIbge = Faker.RandomNumber.Next(1, 100000),
                    FederalUnitId = Guid.NewGuid(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    FederalUnit = new FederalUnitEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        Initials = Faker.Address.UsState().Substring(1 ,3)
                    }
                };
                listCountyEntity.Add(itemCountyEntity);
            }
            //Model => Entity
           var countyEntity = Mapper.Map<CountyEntity>(countyModel);
            Assert.Equal(countyEntity.Id, countyModel.Id);
            Assert.Equal(countyEntity.Name, countyModel.Name);
            Assert.Equal(countyEntity.CodeIbge, countyModel.CodeIbge);
            Assert.Equal(countyEntity.FederalUnitId, countyModel.FederalUnitId);            
            Assert.Equal(countyEntity.CreateAt, countyModel.CreateAt);
            Assert.Equal(countyEntity.UpdateAt, countyModel.UpdateAt);
            //Entity => Dto
            var countyDto = Mapper.Map<CountyDto>(countyEntity);
            Assert.Equal(countyDto.Id, countyEntity.Id);
            Assert.Equal(countyDto.Name, countyEntity.Name);
            Assert.Equal(countyDto.CodeIbge, countyEntity.CodeIbge);
            Assert.Equal(countyDto.FederalUnitId, countyEntity.FederalUnitId);            
            // CompleteDto => Entity 
            var countyCompleteDto = Mapper.Map<CountyCompleteDto>(listCountyEntity.FirstOrDefault());
            Assert.Equal(countyCompleteDto.Id, listCountyEntity.FirstOrDefault().Id);
            Assert.Equal(countyCompleteDto.Name, listCountyEntity.FirstOrDefault().Name);
            Assert.Equal(countyCompleteDto.CodeIbge, listCountyEntity.FirstOrDefault().CodeIbge);
            Assert.Equal(countyCompleteDto.FederalUnitId, listCountyEntity.FirstOrDefault().FederalUnitId);
            Assert.NotNull(countyCompleteDto.FederalUnit);
            // List CountyDto => List CountyEntity 
            var listCountyDto = Mapper.Map<List<CountyDto>>(listCountyEntity);
            Assert.True(listCountyDto.Count() == listCountyEntity.Count());
            for(int i = 0; i < listCountyDto.Count(); i++)
            {
                Assert.Equal(listCountyDto[i].Id, listCountyEntity[i].Id);
                Assert.Equal(listCountyDto[i].Name, listCountyEntity[i].Name);
                Assert.Equal(listCountyDto[i].CodeIbge, listCountyEntity[i].CodeIbge);
                Assert.Equal(listCountyDto[i].FederalUnitId, listCountyEntity[i].FederalUnitId);
            } 
             // County Entity => County Create Result Dto 
            var countyCreateResultDto = Mapper.Map<CountyCreateResultDto>(countyEntity);
            Assert.Equal(countyCreateResultDto.Id, countyEntity.Id);
            Assert.Equal(countyCreateResultDto.Name, countyEntity.Name);
            Assert.Equal(countyCreateResultDto.CodeIbge, countyEntity.CodeIbge);
            Assert.Equal(countyCreateResultDto.FederalUnitId, countyEntity.FederalUnitId);
            // County Entity => County Update Result Dto 
            var countyUpdateResultDto = Mapper.Map<CountyUpdateResultDto>(countyEntity);
            Assert.Equal(countyUpdateResultDto.Id, countyEntity.Id);
            Assert.Equal(countyUpdateResultDto.Name, countyEntity.Name);
            Assert.Equal(countyUpdateResultDto.CodeIbge, countyEntity.CodeIbge);
            Assert.Equal(countyUpdateResultDto.FederalUnitId, countyEntity.FederalUnitId);
            // Dto => Model
            var model = Mapper.Map<CountyModel>(countyDto);
            Assert.Equal(model.Id, countyDto.Id);
            Assert.Equal(model.Name, countyDto.Name);
            Assert.Equal(model.CodeIbge, countyDto.CodeIbge);
            Assert.Equal(model.FederalUnitId, countyDto.FederalUnitId);
            //Model => Create Dto
            var countyCreateDto = Mapper.Map<CountyCreateDto>(model);
            Assert.Equal(countyCreateDto.Name, model.Name);
            Assert.Equal(countyCreateDto.CodeIbge, model.CodeIbge);
            Assert.Equal(countyCreateDto.FederalUnitId, model.FederalUnitId);
            //Model => Update Dto
            var countyUpdateDto = Mapper.Map<CountyUpdateDto>(model);
            Assert.Equal(countyUpdateDto.Id, model.Id);
            Assert.Equal(countyUpdateDto.Name, model.Name);
            Assert.Equal(countyUpdateDto.CodeIbge, model.CodeIbge);
            Assert.Equal(countyUpdateDto.FederalUnitId, model.FederalUnitId);
        }
    }
}