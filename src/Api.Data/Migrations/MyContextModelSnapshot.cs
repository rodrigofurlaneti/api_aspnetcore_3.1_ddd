﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.CountyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CodeIbge")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FederalUnitId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CodeIbge");

                    b.HasIndex("FederalUnitId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Api.Domain.Entities.FederalUnitEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Initials")
                        .IsUnique();

                    b.ToTable("FederalUnit");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9192),
                            Initials = "AC",
                            Name = "Acre",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9232)
                        },
                        new
                        {
                            Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9429),
                            Initials = "AL",
                            Name = "Alagoas",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9435)
                        },
                        new
                        {
                            Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9446),
                            Initials = "AM",
                            Name = "Amazonas",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9449)
                        },
                        new
                        {
                            Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9458),
                            Initials = "AP",
                            Name = "Amapá",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9462)
                        },
                        new
                        {
                            Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9467),
                            Initials = "BA",
                            Name = "Bahia",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9470)
                        },
                        new
                        {
                            Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9578),
                            Initials = "CE",
                            Name = "Ceará",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9580)
                        },
                        new
                        {
                            Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9586),
                            Initials = "DF",
                            Name = "Distrito Federal",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9588)
                        },
                        new
                        {
                            Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9595),
                            Initials = "ES",
                            Name = "Espírito Santo",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9597)
                        },
                        new
                        {
                            Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9608),
                            Initials = "GO",
                            Name = "Goiás",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9610)
                        },
                        new
                        {
                            Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9619),
                            Initials = "MA",
                            Name = "Maranhão",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9623)
                        },
                        new
                        {
                            Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9629),
                            Initials = "MG",
                            Name = "Minas Gerais",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9631)
                        },
                        new
                        {
                            Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9638),
                            Initials = "MS",
                            Name = "Mato Grosso do Sul",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9641)
                        },
                        new
                        {
                            Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9649),
                            Initials = "MT",
                            Name = "Mato Grosso",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9652)
                        },
                        new
                        {
                            Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9659),
                            Initials = "PA",
                            Name = "Pará",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9661)
                        },
                        new
                        {
                            Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9667),
                            Initials = "PB",
                            Name = "Paraíba",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9669)
                        },
                        new
                        {
                            Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9676),
                            Initials = "PE",
                            Name = "Pernambuco",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9679)
                        },
                        new
                        {
                            Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9685),
                            Initials = "PI",
                            Name = "Piauí",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9688)
                        },
                        new
                        {
                            Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9694),
                            Initials = "PR",
                            Name = "Paraná",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9698)
                        },
                        new
                        {
                            Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9705),
                            Initials = "RJ",
                            Name = "Rio de Janeiro",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9707)
                        },
                        new
                        {
                            Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9713),
                            Initials = "RN",
                            Name = "Rio Grande do Norte",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9716)
                        },
                        new
                        {
                            Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9723),
                            Initials = "RO",
                            Name = "Rondônia",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9725)
                        },
                        new
                        {
                            Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9731),
                            Initials = "RR",
                            Name = "Roraima",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9734)
                        },
                        new
                        {
                            Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9741),
                            Initials = "RS",
                            Name = "Rio Grande do Sul",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9744)
                        },
                        new
                        {
                            Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9751),
                            Initials = "SC",
                            Name = "Santa Catarina",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9754)
                        },
                        new
                        {
                            Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9761),
                            Initials = "SE",
                            Name = "Sergipe",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9764)
                        },
                        new
                        {
                            Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9770),
                            Initials = "SP",
                            Name = "São Paulo",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9773)
                        },
                        new
                        {
                            Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9779),
                            Initials = "TO",
                            Name = "Tocantins",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 673, DateTimeKind.Local).AddTicks(9782)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22bfc0cc-bb63-47ad-9675-ab9f5eeab9da"),
                            CreateAt = new DateTime(2020, 12, 8, 11, 33, 44, 668, DateTimeKind.Local).AddTicks(2232),
                            Email = "Administrator@system.com",
                            Name = "Administrator",
                            UpdateAt = new DateTime(2020, 12, 8, 11, 33, 44, 669, DateTimeKind.Local).AddTicks(5016)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.ZipCodeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CountyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.HasIndex("ZipCode");

                    b.ToTable("ZipCode");
                });

            modelBuilder.Entity("Api.Domain.Entities.CountyEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.FederalUnitEntity", "FederalUnit")
                        .WithMany("Counties")
                        .HasForeignKey("FederalUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Domain.Entities.ZipCodeEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.CountyEntity", "County")
                        .WithMany("ZipCodes")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
