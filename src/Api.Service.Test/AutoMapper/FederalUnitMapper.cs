using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Service.Test.Base;
using Xunit;
namespace Api.Service.Test.AutoMapper
{
    public class FederalUnitMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os modelo FederalUnit")]
        public void ItIsPossibleToMapTheModelsFederalUnit()
        {
            var federalUnitModel = new FederalUnitModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                Initials = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
            var listFederalUnitEntity = new List<FederalUnitEntity>();
            for(int i = 0; i < 5; i++)
            {
                var itemFederalUnitEntity = new FederalUnitEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    Initials = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                listFederalUnitEntity.Add(itemFederalUnitEntity);
            }
            //Model => Entity
           var federalUnitEntity = Mapper.Map<FederalUnitEntity>(federalUnitModel);
            Assert.Equal(federalUnitEntity.Id, federalUnitModel.Id);
            Assert.Equal(federalUnitEntity.Name, federalUnitModel.Name);
            Assert.Equal(federalUnitEntity.Initials, federalUnitModel.Initials);
            Assert.Equal(federalUnitEntity.CreateAt, federalUnitModel.CreateAt);
            Assert.Equal(federalUnitEntity.UpdateAt, federalUnitModel.UpdateAt);
            //Entity => Dto
            var listFederalUnitDto = Mapper.Map<List<FederalUnitDto>>(listFederalUnitEntity);
            Assert.True(listFederalUnitDto.Count() == listFederalUnitEntity.Count());
            for(int i = 0; i < listFederalUnitDto.Count(); i++)
            {
                Assert.Equal(listFederalUnitDto[i].Id, listFederalUnitEntity[i].Id);
                Assert.Equal(listFederalUnitDto[i].Name, listFederalUnitEntity[i].Name);
                Assert.Equal(listFederalUnitDto[i].Initials, listFederalUnitEntity[i].Initials);
            }
            // Dto => Model 
            var federalUnitDto = Mapper.Map<FederalUnitDto>(federalUnitModel);
            Assert.Equal(federalUnitDto.Id, federalUnitModel.Id);
            Assert.Equal(federalUnitDto.Name, federalUnitModel.Name);
            Assert.Equal(federalUnitDto.Initials, federalUnitModel.Initials);
        }
    }
}