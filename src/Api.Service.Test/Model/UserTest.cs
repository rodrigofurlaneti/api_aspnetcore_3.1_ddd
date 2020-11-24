using System;
using System.Collections.Generic;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
namespace Api.Service.Test
{
    public class UserTest
    {
        public static Guid IdUser { get; set; }
        public static string NameCreate{ get; set;}
        public static string EmailCreate{ get; set;}
        public static string NameUpdate{ get; set;}
        public static string EmailUpdate{ get; set;}
        public List<UserDto> ListUserDto = new List<UserDto>();
        public UserDto userDto;
        public UserCreateResultDto userCreateResultDto; 
        public UserUpdateResultDto userUpdateResultDto; 
        public UserTest()
        {
            NameCreate = Faker.Name.FullName();
            EmailCreate = Faker.Internet.Email();
            NameUpdate = Faker.Name.FullName();
            EmailUpdate = Faker.Internet.Email();
            for(int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                ListUserDto.Add(dto);
            }
            userDto = new UserDto
            {
                Name = NameCreate,
                Email = EmailCreate
            };
            userCreateResultDto = new UserCreateResultDto
            {
                Id = Guid.NewGuid(),
                Name = NameCreate,
                Email = EmailCreate,
                CreateAt = DateTime.Now

            };
            userUpdateResultDto = new UserUpdateResultDto
            {
                Id = userCreateResultDto.Id,
                Name = NameCreate,
                Email = EmailCreate,
                UpdateAt = DateTime.Now
            };
        }
    }
}