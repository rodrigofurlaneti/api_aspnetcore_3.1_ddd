using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Service.Test.Base;
using Xunit;
namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel mapear os modelos")]
        public void ItIsPossibleToMapTheModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listEntity = new List<UserEntity>();
            for(int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                listEntity.Add(item);
            }

            //Model => Entity
            var entityMapper = Mapper.Map<UserEntity>(model);
            Assert.Equal(entityMapper.Id, model.Id);
            Assert.Equal(entityMapper.Name, model.Name);
            Assert.Equal(entityMapper.Email, model.Email);
            Assert.Equal(entityMapper.CreateAt, model.CreateAt);
            Assert.Equal(entityMapper.UpdateAt, model.UpdateAt);
            
            //Entity => Dto
            var userDto = Mapper.Map<UserDto>(entityMapper);
            Assert.Equal(userDto.Id, entityMapper.Id);
            Assert.Equal(userDto.Name, entityMapper.Name);
            Assert.Equal(userDto.Email, entityMapper.Email);
            Assert.Equal(userDto.CreateAt, entityMapper.CreateAt);
            
            //
            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for(int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }

            var userCreateResultDto = Mapper.Map<UserCreateResultDto>(entityMapper);
            Assert.Equal(userCreateResultDto.Id, entityMapper.Id);
            Assert.Equal(userCreateResultDto.Name, entityMapper.Name);
            Assert.Equal(userCreateResultDto.Email, entityMapper.Email);
            Assert.Equal(userCreateResultDto.CreateAt, entityMapper.CreateAt);           
        
            var userUpdateResultDto = Mapper.Map<UserUpdateResultDto>(entityMapper);
            Assert.Equal(userUpdateResultDto.Id, entityMapper.Id);
            Assert.Equal(userUpdateResultDto.Name, entityMapper.Name);
            Assert.Equal(userUpdateResultDto.Email, entityMapper.Email);
            Assert.Equal(userUpdateResultDto.UpdateAt, entityMapper.UpdateAt);           
        }
    }
}