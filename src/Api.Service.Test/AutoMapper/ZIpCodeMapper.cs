using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Service.Test.Base;
using Xunit;
namespace Api.Service.Test.AutoMapper
{
    public class ZipCodeMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os modelo ZipCode")]
        public void ItIsPossibleToMapTheModelsZipCode()
        {
            var model = new ZipCodeModel
            {
                Id = Guid.NewGuid(),
                ZipCode = Faker.RandomNumber.Next(1,10000).ToString(),
                PublicPlace = Faker.Address.StreetName(),
                Number = "",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                CountyId = Guid.NewGuid()
            };
            var listZipCodeEntity = new List<ZipCodeEntity>();
            for(int i = 0; i < 5; i++)
            {
                var itemZipCodeEntity = new ZipCodeEntity
                {
                    Id = Guid.NewGuid(),
                    ZipCode = Faker.RandomNumber.Next(1,10000).ToString(),
                    PublicPlace = Faker.Address.StreetName(),
                    Number = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CountyId = Guid.NewGuid(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    County = new CountyEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        CodeIbge = Faker.RandomNumber.Next(1, 10000),
                        FederalUnitId = Guid.NewGuid(),
                        FederalUnit = new FederalUnitEntity
                        {
                            Id = Guid.NewGuid(),
                            Name = Faker.Address.UsState(),
                            Initials = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listZipCodeEntity.Add(itemZipCodeEntity);
            }
            #region Model => Entity 
                //Model => Entity
                var zipCodeEntity = Mapper.Map<ZipCodeEntity>(model);
                Assert.Equal(zipCodeEntity.Id, model.Id);
                Assert.Equal(zipCodeEntity.PublicPlace, model.PublicPlace);
                Assert.Equal(zipCodeEntity.Number, model.Number);
                Assert.Equal(zipCodeEntity.CreateAt, model.CreateAt);
                Assert.Equal(zipCodeEntity.UpdateAt, model.UpdateAt);
            #endregion
            #region Entity => Dto 
                //Entity => Dto
                var zipCodeDto = Mapper.Map<ZipCodeDto>(zipCodeEntity);
                Assert.Equal(zipCodeDto.Id, zipCodeEntity.Id);
                Assert.Equal(zipCodeDto.PublicPlace, zipCodeEntity.PublicPlace);
                Assert.Equal(zipCodeDto.Number, zipCodeEntity.Number);
                Assert.Equal(zipCodeDto.ZipCode, zipCodeEntity.ZipCode);            
            #endregion
            #region CompleteDto => Entity  
                // CompleteDto => Entity 
                var zipCodeCompleteDto = Mapper.Map<ZipCodeDto>(listZipCodeEntity.FirstOrDefault());
                Assert.Equal(zipCodeCompleteDto.Id, listZipCodeEntity.FirstOrDefault().Id);
                Assert.Equal(zipCodeCompleteDto.PublicPlace, listZipCodeEntity.FirstOrDefault().PublicPlace);
                Assert.Equal(zipCodeCompleteDto.Number, listZipCodeEntity.FirstOrDefault().Number);
                Assert.NotNull(zipCodeCompleteDto.County);
                Assert.NotNull(zipCodeCompleteDto.County.FederalUnitId);
            #endregion
            #region List ZipCodeDto => List ZipCodeEntity
                //List ZipCodeDto => List ZipCodeEntity 
                var listZipCodeDto = Mapper.Map<List<ZipCodeDto>>(listZipCodeEntity);
                Assert.True(listZipCodeDto.Count() == listZipCodeEntity.Count());
                for(int i = 0; i < listZipCodeDto.Count(); i++)
                {
                    Assert.Equal(listZipCodeDto[i].Id, listZipCodeEntity[i].Id);
                    Assert.Equal(listZipCodeDto[i].ZipCode, listZipCodeEntity[i].ZipCode);
                    Assert.Equal(listZipCodeDto[i].PublicPlace, listZipCodeEntity[i].PublicPlace);
                    Assert.Equal(listZipCodeDto[i].Number, listZipCodeEntity[i].Number);
                }
            #endregion
            #region ZipCode Entity => ZipCode Create Result Dto 
                // ZipCode Entity => ZipCode Create Result Dto 
                var zipCodeCreateResultDto = Mapper.Map<ZipCodeCreateResultDto>(zipCodeEntity);
                Assert.Equal(zipCodeCreateResultDto.Id, zipCodeEntity.Id);
                Assert.Equal(zipCodeCreateResultDto.ZipCode, zipCodeEntity.ZipCode);
                Assert.Equal(zipCodeCreateResultDto.PublicPlace, zipCodeEntity.PublicPlace);
                Assert.Equal(zipCodeCreateResultDto.Number, zipCodeEntity.Number);
            #endregion
            #region ZipCode Entity => ZipCode Update Result Dto 
                // ZipCode Entity => ZipCode Update Result Dto 
                var zipCodeUpdateResultDto = Mapper.Map<ZipCodeUpdateResultDto>(zipCodeEntity);
                Assert.Equal(zipCodeUpdateResultDto.Id, zipCodeEntity.Id);
                Assert.Equal(zipCodeUpdateResultDto.ZipCode, zipCodeEntity.ZipCode);
                Assert.Equal(zipCodeUpdateResultDto.PublicPlace, zipCodeEntity.PublicPlace);
                Assert.Equal(zipCodeUpdateResultDto.Number, zipCodeEntity.Number);
            #endregion
            #region Dto => Model
                // Dto => Model
                zipCodeDto.Number = "";
                var zipCodemodel = Mapper.Map<ZipCodeModel>(zipCodeDto);
                Assert.Equal(zipCodemodel.Id, zipCodeDto.Id);
                Assert.Equal(zipCodemodel.ZipCode, zipCodeDto.ZipCode);
                Assert.Equal(zipCodemodel.PublicPlace, zipCodeDto.PublicPlace);
                Assert.Equal("S/N", zipCodeDto.Number);
            #endregion
            #region Model => Create Dto 
                //Model => Create Dto
                var zipCodeCreateDto = Mapper.Map<ZipCodeCreateDto>(model);
                Assert.Equal(zipCodeCreateDto.ZipCode, model.ZipCode);
                Assert.Equal(zipCodeCreateDto.PublicPlace, model.PublicPlace);
                Assert.Equal(zipCodeCreateDto.Number, model.Number);
            #endregion
            #region Model => Update Dto 
                //Model => Update Dto
                var zipCodeUpdateDto = Mapper.Map<ZipCodeUpdateDto>(model);
                Assert.Equal(zipCodeUpdateDto.Id, model.Id);
                Assert.Equal(zipCodeUpdateDto.ZipCode, model.ZipCode);
                Assert.Equal(zipCodeUpdateDto.PublicPlace, model.PublicPlace);
                Assert.Equal(zipCodeUpdateDto.Number, model.Number);
            #endregion
        }
    }
}