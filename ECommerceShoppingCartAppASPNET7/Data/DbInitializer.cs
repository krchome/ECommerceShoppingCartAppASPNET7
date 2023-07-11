using ECommerceShoppingCartAppASPNET7.Models;
using System;
using System.Linq;

namespace ECommerceShoppingCartAppASPNET7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();
            //Look for any products
            if (context.Products.Any())
            {
                return;//DB has been seeded
            }
            var products = new Product[]
            {
                  new Product()
                  {
                      Id = "1",
                     Name = "Flower1",
                      Photo = "thumb1.jpg",
                      Price = 2.80
                  },

                new Product()
                {
                    Id="2",
                    Name = "Flower2",
                    Photo = "thumb2.jpg",
                    Price = 3.80
                },
                new Product()
                {
                    Id="3",
                    Name = "Flower3",
                    Photo = "thumb3.jpg",
                    Price = 3.80
                },
                  new Product()
                  {
                      Id="4",
                      Name = "Flower4",
                      Photo = "thumb4.jpg",
                      Price = 3.60
                  },
                new Product()
                {
                    Id="5",
                    Name = "Flower5",
                    Photo = "thumb5.jpg",
                    Price = 6.80
                },
                new Product()
                {
                    Id="6",
                    Name = "Flower6",
                    Photo = "thumb6.jpg",
                    Price = 1.68
                },
                  new Product()
                  {
                      Id="7",
                      Name = "Flower7",
                      Photo = "thumb7.jpg",
                      Price = 3.80
                  },
                  new Product()
                  {
                      Id="8",
                      Name = "Flower8",
                      Photo = "thumb8.jpg",
                      Price = 3.45
                  },
                new Product()
                {
                    Id = "9",
                    Name = "Flower9",
                    Photo = "thumb9.jpg",
                    Price = 3.80
                }
                  
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

        }
    }
}
