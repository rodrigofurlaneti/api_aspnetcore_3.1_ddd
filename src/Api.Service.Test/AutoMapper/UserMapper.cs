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
           var dtoToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);
            
            //Entity => Dto
            UserDto userDto = Mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(userDto.Id, dtoToEntity.Id);
            Assert.Equal(userDto.Name, dtoToEntity.Name);
            Assert.Equal(userDto.Email, dtoToEntity.Email);
            Assert.Equal(userDto.CreateAt, dtoToEntity.CreateAt);
            
            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for(int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }

            var userCreateResultDto = Mapper.Map<UserCreateResultDto>(dtoToEntity);
            Assert.Equal(userCreateResultDto.Id, dtoToEntity.Id);
            Assert.Equal(userCreateResultDto.Name, dtoToEntity.Name);
            Assert.Equal(userCreateResultDto.Email, dtoToEntity.Email);
            Assert.Equal(userCreateResultDto.CreateAt, dtoToEntity.CreateAt);           
        
            var userUpdateResultDto = Mapper.Map<UserUpdateResultDto>(dtoToEntity);
            Assert.Equal(userUpdateResultDto.Id, dtoToEntity.Id);
            Assert.Equal(userUpdateResultDto.Name, dtoToEntity.Name);
            Assert.Equal(userUpdateResultDto.Email, dtoToEntity.Email);
            Assert.Equal(userUpdateResultDto.UpdateAt, dtoToEntity.UpdateAt);           
        }
    }
}