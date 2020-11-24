using System;
using System.Collections.Generic;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
namespace Api.Service.Test
{
    public class UserTest
    {
        public static Guid idCreate { get; set; }
        public static string nameCreate{ get; set;}
        public static string emailCreate{ get; set;}
        public static string nameUpdate{ get; set;}
        public static string emailUpdate{ get; set;}
        public List<UserCreateDto> listUserDto = new List<UserCreateDto>();
        public UserDto userDto;
        public UserCreateDto userCreateDto; 
        public UserCreateResultDto userCreateResultDto; 
        public UserUpdateResultDto userUpdateResultDto; 
        public UserTest()
        {
            idCreate = Guid.NewGuid();
            nameCreate = Faker.Name.FullName();
            emailCreate = Faker.Internet.Email();
            nameUpdate = Faker.Name.FullName();
            emailUpdate = Faker.Internet.Email();
            
            //Preencher a lista
            for(int i = 0; i < 10; i++)
            {
                var dto = new UserCreateDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Name = nameCreate,
                Email = emailCreate
            };

            userCreateDto = new UserCreateDto
            {
                Id = idCreate,
                Name = nameCreate,
                Email = emailCreate
            };

            userCreateResultDto = new UserCreateResultDto
            {
                Id = idCreate,
                Name = nameCreate,
                Email = emailCreate,
                CreateAt = DateTime.Now
            };

            userUpdateResultDto = new UserUpdateResultDto
            {
                Id = idCreate,
                Name = nameCreate,
                Email = emailCreate,
                UpdateAt = DateTime.Now
            };
        }
    }
}