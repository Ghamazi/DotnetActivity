using Microsoft.EntityFrameworkCore;
using DotnetActivity.Context;
using System;



namespace DotnetActivity.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {




        }
       
        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "ITem1"
                    
                    
                },
                    new Category()
                    {
                        Id = Guid.Parse("d38888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        Name = "ITem2"


                    },
                        new Category()
                        {
                            Id = Guid.Parse("d48888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "ITem3"


                        }


                );

            modelBuilder.Entity<Products>().HasData(
               new Products
               {

                   Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                   Name = "arcade",
                   price = 10,
                   ImgUrl="IMg1.png",
                   Quantity=2,
                   CategoryId= Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
               },
               new Products
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   Name = "color",
                   price = 120,
                   ImgUrl = "IMg21.png",
                   Quantity = 12,
                   CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
               },
                  new Products
                  {

                      Id = Guid.Parse("2ee50fe3-edf2-4f91-8409-3eb25ce6ca51"),
                      Name = "arcade",
                      price = 10,
                      ImgUrl = "IMg1.png",
                      Quantity = 2,
                      CategoryId = Guid.Parse("d38888e9-2ba9-473a-a40f-e38cb54f9b35")
                  },
                     new Products
                     {

                         Id = Guid.Parse("2ee51fe3-edf2-4f91-8409-3eb25ce6ca51"),
                         Name = "arcade",
                         price = 10,
                         ImgUrl = "IMg1.png",
                         Quantity = 2,
                         CategoryId = Guid.Parse("d48888e9-2ba9-473a-a40f-e38cb54f9b35")
                     }



               );

            base.OnModelCreating(modelBuilder);


        }
    }
}
