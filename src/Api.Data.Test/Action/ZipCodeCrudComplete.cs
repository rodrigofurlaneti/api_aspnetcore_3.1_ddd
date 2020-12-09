using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Test.Base;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
namespace Api.Data.Test.Action
{
    public class ZipCodeCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public ZipCodeCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }
        [Fact(DisplayName="Crud do cep")]
        [Trait("CRUD", "ZipCodeEntity")]
        public async Task ItIsPossibleToCarryOutTheZipCodeCrud()
        {
            using(var myContext = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation countyImplementation = new CountyImplementation(myContext);
                CountyEntity countyEntity = new CountyEntity
                {
                    Name = Faker.Address.City(),
                    CodeIbge = Faker.RandomNumber.Next(1000000, 9999999),
                    FederalUnitId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };
                var recordCounty = await countyImplementation.InsertAsync(countyEntity);
                Assert.NotNull(recordCounty);
                Assert.Equal(countyEntity.Name, recordCounty.Name);
                Assert.Equal(countyEntity.CodeIbge, recordCounty.CodeIbge);
                Assert.Equal(countyEntity.FederalUnitId, recordCounty.FederalUnitId);
                Assert.False(recordCounty.Id == Guid.Empty);
                ZipCodeImplementation zipCodeImplementation = new ZipCodeImplementation(myContext);
                ZipCodeEntity zipCodeEntity = new ZipCodeEntity
                {
                    ZipCode = "13.481-001",
                    PublicPlace = Faker.Address.StreetName(),
                    Number = "0 até 2000",
                    CountyId = recordCounty.Id
                };
                var recordZipCode = await zipCodeImplementation.InsertAsync(zipCodeEntity);
                Assert.NotNull(recordZipCode);
                Assert.Equal(zipCodeEntity.ZipCode, recordZipCode.ZipCode);
                Assert.Equal(zipCodeEntity.PublicPlace, recordZipCode.PublicPlace);
                Assert.Equal(zipCodeEntity.Number, recordZipCode.Number);
                Assert.Equal(zipCodeEntity.CountyId, recordZipCode.CountyId);
                Assert.False(recordZipCode.Id == Guid.Empty);
                zipCodeEntity.PublicPlace = Faker.Address.StreetName();
                zipCodeEntity.Id = recordZipCode.Id;
                var recordUpdate = await zipCodeImplementation.UpdateAsync(zipCodeEntity);
                Assert.NotNull(recordUpdate);
                Assert.Equal(zipCodeEntity.ZipCode, recordUpdate.ZipCode);
                Assert.Equal(zipCodeEntity.PublicPlace, recordUpdate.PublicPlace);
                Assert.Equal(zipCodeEntity.Number, recordUpdate.Number);
                Assert.Equal(zipCodeEntity.CountyId, recordUpdate.CountyId);
                Assert.True(recordZipCode.Id == zipCodeEntity.Id);
                var recordExists = await zipCodeImplementation.ExistAsync(recordUpdate.Id);
                Assert.True(recordExists);
                var recordSelect = await zipCodeImplementation.SelectAsync(recordUpdate.Id);
                Assert.NotNull(recordSelect);
                Assert.Equal(recordSelect.ZipCode, recordUpdate.ZipCode);
                Assert.Equal(recordSelect.PublicPlace, recordUpdate.PublicPlace);
                Assert.Equal(recordSelect.Number, recordUpdate.Number);
                Assert.Equal(recordSelect.CountyId, recordUpdate.CountyId);
                recordSelect = await zipCodeImplementation.SelectAsync(recordUpdate.ZipCode);
                Assert.NotNull(recordSelect);
                Assert.Equal(recordSelect.ZipCode, recordUpdate.ZipCode);
                Assert.Equal(recordSelect.PublicPlace, recordUpdate.PublicPlace);
                Assert.Equal(recordSelect.Number, recordUpdate.Number);
                Assert.Equal(recordSelect.CountyId, recordUpdate.CountyId);
                Assert.NotNull(recordSelect.County);
                Assert.NotNull(recordSelect.County.Id);
                Assert.Equal(recordSelect.County.Name, countyEntity.Name);
                Assert.Equal(recordSelect.County.FederalUnit.Initials, "SP");
                var recordSelectAll = await zipCodeImplementation.SelectAsync();
                Assert.NotNull(recordSelectAll);
                Assert.True(recordSelectAll.Count() > 0);
                var recordDelete = await zipCodeImplementation.DeleteAsync(recordSelect.Id);
                Assert.True(recordDelete);
                recordSelectAll = await zipCodeImplementation.SelectAsync();
                Assert.NotNull(recordSelectAll);
                Assert.True(recordSelectAll.Count() == 0);
            }
        }
    }
}