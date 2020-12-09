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
    public class CountyCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public CountyCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }
        [Fact(DisplayName="Crud do município")]
        [Trait("CRUD", "CountyEntity")]
        public async Task ItIsPossibleToCarryOutTheCountyCrud()
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
                var record = await countyImplementation.InsertAsync(countyEntity);
                Assert.NotNull(record);
                Assert.Equal(countyEntity.Name, record.Name);
                Assert.Equal(countyEntity.CodeIbge, record.CodeIbge);
                Assert.Equal(countyEntity.FederalUnitId, record.FederalUnitId);
                Assert.False(record.Id == Guid.Empty);
                countyEntity.Name = Faker.Address.City();
                countyEntity.Id = record.Id;
                var recordUpdate = await countyImplementation.UpdateAsync(countyEntity);
                Assert.NotNull(recordUpdate);
                Assert.Equal(countyEntity.Name, recordUpdate.Name);
                Assert.Equal(countyEntity.CodeIbge, recordUpdate.CodeIbge);
                Assert.Equal(countyEntity.FederalUnitId, recordUpdate.FederalUnitId);
                Assert.True(record.Id == countyEntity.Id);
                var recordExists = await countyImplementation.ExistAsync(countyEntity.Id);
                Assert.True(recordExists);
                var recordSelect = await countyImplementation.SelectAsync(countyEntity.Id);
                Assert.NotNull(recordSelect);
                Assert.Equal(recordUpdate.Name, recordSelect.Name);
                Assert.Equal(recordUpdate.CodeIbge, recordSelect.CodeIbge);
                Assert.Equal(recordUpdate.FederalUnitId, recordSelect.FederalUnitId);
                Assert.Null(recordSelect.FederalUnit);
                recordSelect = await countyImplementation.GetCompleteByIbgeAsync(recordUpdate.CodeIbge);
                Assert.NotNull(recordSelect);
                Assert.Equal(recordUpdate.Name, recordSelect.Name);
                Assert.Equal(recordUpdate.CodeIbge, recordSelect.CodeIbge);
                Assert.Equal(recordUpdate.FederalUnitId, recordSelect.FederalUnitId);
                Assert.NotNull(recordSelect.FederalUnit);
                recordSelect = await countyImplementation.GetCompleteByIdAsync(recordUpdate.Id);
                Assert.NotNull(recordSelect);
                Assert.Equal(recordUpdate.Name, recordSelect.Name);
                Assert.Equal(recordUpdate.CodeIbge, recordSelect.CodeIbge);
                Assert.Equal(recordUpdate.FederalUnitId, recordSelect.FederalUnitId);
                Assert.NotNull(recordSelect.FederalUnit);
                var allRecord = await countyImplementation.SelectAsync();
                Assert.NotNull(allRecord);
                Assert.True(allRecord.Count() > 0);
                var deleteRecord = await countyImplementation.DeleteAsync(recordSelect.Id);
                Assert.True(deleteRecord);
                allRecord = await countyImplementation.SelectAsync();
                Assert.NotNull(allRecord);
                Assert.True(allRecord.Count() == 0);
            }
        }
    }
}