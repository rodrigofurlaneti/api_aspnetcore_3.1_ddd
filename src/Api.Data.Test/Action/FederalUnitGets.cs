using System;
using System.Collections.Generic;
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
    public class FederalUnitGets : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public FederalUnitGets(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }
        [Fact(DisplayName = "Gets de UF")]
        [Trait("GETs", "FederalUnitEntity")]
        public async Task ItIsPossibleToMakeRequestsForFederalUnit()
        {
            using(var myContext = _serviceProvider.GetService<MyContext>())
            {
                FederalUnitImplementation federalUnitImplementation = new FederalUnitImplementation(myContext);
                FederalUnitEntity federalUnitEntity = new FederalUnitEntity
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Initials = "SP",
                    Name = "São Paulo"
                };
                bool recordExists = await federalUnitImplementation.ExistAsync(federalUnitEntity.Id);
                Assert.True(recordExists);
                FederalUnitEntity recordSelect = await federalUnitImplementation.SelectAsync(federalUnitEntity.Id);
                Assert.NotNull(recordSelect);
                Assert.Equal(federalUnitEntity.Initials, recordSelect.Initials);
                Assert.Equal(federalUnitEntity.Name, recordSelect.Name);
                Assert.Equal(federalUnitEntity.Id, recordSelect.Id);
                IEnumerable<FederalUnitEntity> allRecords = await federalUnitImplementation.SelectAsync();
                Assert.NotNull(allRecords);
                Assert.True(allRecords.Count() == 27);
            }
        }
    }
}