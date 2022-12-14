// <auto-generated />
using System;
using DotnetActivity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotnetActivity.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221026162224_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DotnetActivity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "ITem1"
                        },
                        new
                        {
                            Id = new Guid("d38888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "ITem2"
                        },
                        new
                        {
                            Id = new Guid("d48888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "ITem3"
                        });
                });

            modelBuilder.Entity("DotnetActivity.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            CategoryId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ImgUrl = "IMg1.png",
                            Name = "arcade",
                            Quantity = 2,
                            price = 10f
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            CategoryId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ImgUrl = "IMg21.png",
                            Name = "color",
                            Quantity = 12,
                            price = 120f
                        },
                        new
                        {
                            Id = new Guid("2ee50fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            CategoryId = new Guid("d38888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ImgUrl = "IMg1.png",
                            Name = "arcade",
                            Quantity = 2,
                            price = 10f
                        },
                        new
                        {
                            Id = new Guid("2ee51fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            CategoryId = new Guid("d48888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ImgUrl = "IMg1.png",
                            Name = "arcade",
                            Quantity = 2,
                            price = 10f
                        });
                });

            modelBuilder.Entity("DotnetActivity.Products", b =>
                {
                    b.HasOne("DotnetActivity.Category", "Category")
                        .WithMany("ProductsUnderThisCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DotnetActivity.Category", b =>
                {
                    b.Navigation("ProductsUnderThisCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
