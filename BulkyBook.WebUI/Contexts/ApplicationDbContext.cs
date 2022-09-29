using BulkyBook.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.WebUI.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.DisplayOrder).HasColumnName("DisplayOrder");
                a.Property(p => p.CreatedDateTime).HasColumnName("CreatedDateTime");
                a.HasMany(p => p.SubCategories);
            });

            Category[] categorySeeds = { new(1, "Literature", 11), new(2, "Preparation for Exams", 22) };
            modelBuilder.Entity<Category>().HasData(categorySeeds);

            modelBuilder.Entity<SubCategory>(a =>
            {
                a.ToTable("SubCategories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CategoryId).HasColumnName("CategoryId");
                a.HasMany(p => p.Books);
                a.HasOne(p => p.Category);
            });

            SubCategory[] subCategorySeeds = { new(1, 1, "Story"), new(2, 1, "Novel"), new(3, 2, "TYT"), new(4, 2, "DGS") };
            modelBuilder.Entity<SubCategory>().HasData(subCategorySeeds);

            modelBuilder.Entity<Book>(a =>
            {
                a.ToTable("Books").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Publisher).HasColumnName("Publisher");
                a.Property(p => p.Writer).HasColumnName("Writer");
                a.Property(p => p.Price).HasColumnName("Price");
                a.HasOne(p => p.SubCategory);
            });

            Book[] bookSeeds = { 
                new(1,1,"Üç Kız Kardeş", "İş Bankası Kültür Yayınları", "Anton Pavloviç Çehov", 23.40m),
                new(2,2,"Bir Çöküşün Öyküsü", "İş Bankası Kültür Yayınları", "Stefan Zweig", 16.20m),
                new(3,3,"Esen TYT Matematik Orta İleri Düzey Soru Bankası", "Esen Yayınları", "Nevzat Asma, Halit Bıyık", 45.90m),
                new(4,4,"2022 DGS 6 Muhteşem Fasikül Fasikül Deneme", "Tasarı Eğitim Yayınları", "Özgen Bulut", 53.40m)
            };
            modelBuilder.Entity<Book>().HasData(bookSeeds);

        }
    }
}
