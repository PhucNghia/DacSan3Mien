namespace DacSan3Mien.Migrations
{
    using DacSan3Mien.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //using System.Web.WebPages.Html;

    using System.Web.Mvc;

    internal sealed class Configuration : DbMigrationsConfiguration<DacSan3Mien.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DacSan3Mien.Models.DataContext";
        }

        protected override void Seed(DacSan3Mien.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var users = new List<User>();
            string name, role, email;
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    name = "Admin";
                    role = "admin";
                    email = "admin@gmail.com";
                }
                else
                {
                    name = "User" + i;
                    role = "user";
                    email = "user" + i + "@gmail.com";
                }
                users.Add(new User
                {
                    name = name,
                    email = email,
                    birthday = "21/08/1997",
                    gender = "Nam",
                    listGender = null,
                    phone = "0382305339",
                    address = "HN",
                    password = "111111",
                    confirmPassword = "111111",
                    role = role
                });
            }
            users.ForEach(u => context.Users.AddOrUpdate(p => p.id, u));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region{name = "Miền Bắc"},
                new Region{name = "Miền Trung"},
                new Region{name = "Miền Nam"}
            };
            regions.ForEach(r => context.Regions.AddOrUpdate(p => p.name, r));
            context.SaveChanges();

            var products = new List<Product>();
            int regionId = 1;
            for (int i = 0; i < 10; i++)
            {
                regionId = (i % 3 == 0) ? 1 : regionId + 1;
                Product p = new Product
                {
                    name = "San Pham " + (i + 1),
                    image = "product_" + (i + 1) + ".jpg",
                    price = 10000 + i * 10000,
                    status = "in stock",
                    description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                    regionId = regionId
                };
                products.Add(p);
            };
            products.ForEach(r => context.Products.AddOrUpdate(p => p.id, r));
            context.SaveChanges();
        }
    }
}
