using System;
using System.Collections.Generic;
using Api.Domain.Dtos.FederalUnit;
namespace Api.Service.Test.Model
{
    public class FederalUnitTest
    {
        public static string Name{ get; set;}
        public static string Initials{ get; set;}
        public static Guid Id{ get; set;}
        public List<FederalUnitDto> listFederalUnitDto = new List<FederalUnitDto>();
        public FederalUnitDto federalUnitDto;
        public FederalUnitTest()
        {
            Id = Guid.NewGuid();
            Initials = Faker.Address.UsState().Substring(1, 3);
            Name = Faker.Address.UsState();
            //Preencher a lista
            for(int i = 0; i < 10; i++)
            {
                var dto = new FederalUnitDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Initials = Faker.Address.UsState().Substring(1,3)
                };
                listFederalUnitDto.Add(dto);
            }

            federalUnitDto = new FederalUnitDto
            {
                Id = Id,
                Name = Name,
                Initials = Initials
            };
        }
    }
}