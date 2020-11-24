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
            var obj = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listEntity = new List<UserEntity>();
            for(int i = 0; i < 5; i ++)
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

            var entity = Mapper.Map<UserEntity>(obj);
            Assert.Equal(entity.Id, obj.Id);
            Assert.Equal(entity.Name, obj.Name);
            Assert.Equal(entity.Email, obj.Email);
            Assert.Equal(entity.CreateAt, obj.CreateAt);
            Assert.Equal(entity.UpdateAt, obj.UpdateAt);
            
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);
            
            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for(int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }

            var userCreateResultDto = Mapper.Map<UserCreateResultDto>(entity);
            Assert.Equal(userCreateResultDto.Id, entity.Id);
            Assert.Equal(userCreateResultDto.Name, entity.Name);
            Assert.Equal(userCreateResultDto.Email, entity.Email);
            Assert.Equal(userCreateResultDto.CreateAt, entity.CreateAt);           
        
            var userUpdateResultDto = Mapper.Map<UserUpdateResultDto>(entity);
            Assert.Equal(userUpdateResultDto.Id, entity.Id);
            Assert.Equal(userUpdateResultDto.Name, entity.Name);
            Assert.Equal(userUpdateResultDto.Email, entity.Email);
            Assert.Equal(userUpdateResultDto.UpdateAt, entity.UpdateAt);           
        }
    }
}