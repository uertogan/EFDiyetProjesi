using DiyetProje.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetProje.DAL.Context
{
    public class DiyetDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMealProduct> UserMealProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LENOVO-V15IIL;Database = DiyetDB;User Id = sa;Password = 123456;TrustServerCertificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bilge",
                    LastName = "Adam",
                    Email = "admin@bilgeadam.com",
                    Password = "123",
                    Age = 25,
                    Weight = 60,
                    Height = 180,
                    Gender = "Kadın",
                    IsAdministrator = true,
                    CreatedDate = DateTime.Now,
                    Status = Enums.DataStatus.Added
                });

            modelBuilder.Entity<Meal>().HasData(
                new Meal() { Id = 1, MealName = "Sabah", Description = "Saat aralığı: 07:00 - 11:00", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added },
                new Meal() { Id = 2, MealName = "Öğle", Description = "Saat aralığı: 11:00 - 13:00", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added },
                new Meal() { Id = 3, MealName = "Akşam", Description = "Saat aralığı: 17:00 - 20:00", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, CategoryName = "İçecekler", Description = "Alkolsüz içecekler, kahveler, çaylar", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added },
                new Category() { Id = 2, CategoryName = "Süt Ürünleri", Description = "Süt, yoğurt, peynir, CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added" },
                new Category() { Id = 3, CategoryName = "Kurutulmuş Meyve", Description = "Kayısı, incir, üzüm, hurma", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added },
                new Category() { Id = 4, CategoryName = "Şekerlemeler", Description = "Helva, Pişmaniye", CreatedDate = DateTime.Now, Status = Enums.DataStatus.Added }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1, // BaseEntity'den gelen Id
                    ProductName = "Su",
                    PortionUnit = 1,
                    Description = "1 litre su 1 porsiyona denk",
                    Picture = null, // Varsayılan olarak resim yok
                    CategoryId = 1 // Varsayılan kategori
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Kayısı",
                    PortionUnit = 1,
                    Description = "4 tane kayısı 1 porsiyona denk",
                    Picture = null,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Elma",
                    PortionUnit = 1,
                    Description = "2 dilim elma 1 porsiyona denk",
                    Picture = null,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Pişmaniye",
                    PortionUnit = 1,
                    Description = "350 gram pişmaniye 1 porsiyona denk",
                    Picture = null,
                    CategoryId = 4
                });
        }
    }
}
