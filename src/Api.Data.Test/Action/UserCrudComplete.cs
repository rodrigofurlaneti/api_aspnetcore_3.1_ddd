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
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public UserCrudComplete(DbTest dbtest)
        {
            _serviceProvider = dbtest.serviceProvider;
        }
        [Fact(DisplayName = "Crud de usuário")]
        [Trait("Crud", "UserEntity")]
        public async Task PerformUserCrud()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                { 
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                //Test InsertAsync
                UserEntity _recordCreated = await _repository.InsertAsync(_entity);
                Assert.NotNull(_recordCreated);
                Assert.Equal(_entity.Email, _recordCreated.Email);
                Assert.Equal(_entity.Name, _recordCreated.Name);
                Assert.False(_recordCreated.Id == Guid.Empty);
                _entity.Name = Faker.Name.First();
                
                //Test Update
                UserEntity _recordUpdate = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_recordUpdate);
                Assert.Equal(_entity.Email, _recordUpdate.Email);
                Assert.Equal(_entity.Name, _recordUpdate.Name);
 
                //Test Exist
                bool _recordExist = await _repository.ExistAsync(_recordUpdate.Id);
                Assert.True(_recordExist);

                //Test Select
                UserEntity _recordSelect = await _repository.SelectAsync(_recordUpdate.Id);
                Assert.NotNull(_recordSelect);
                Assert.Equal(_recordUpdate.Email, _recordSelect.Email);
                Assert.Equal(_recordUpdate.Name, _recordSelect.Name);

                //Test GetAll
                IEnumerable<UserEntity> _recordGetAll = await _repository.SelectAsync();
                Assert.NotNull(_recordGetAll);
                Assert.True(_recordGetAll.Count() > 1);

                //Test Exist
                bool _recordDelete = await _repository.DeleteAsync(_recordUpdate.Id);
                Assert.True(_recordDelete);
                
                //Test FindByLogin
                UserEntity _defaultUser = await _repository.FindByLoginAsync("Administrator@system.com");
                Assert.NotNull(_defaultUser);
                Assert.Equal("Administrator", _defaultUser.Name);
                Assert.Equal("Administrator@system.com", _defaultUser.Email);
            }        
        }
    }
}