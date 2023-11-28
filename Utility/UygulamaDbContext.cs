﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models;

//Veri Tabanında EF Tablo oluşturması için ilgili model sınıflarımızı buraya eklemelisinizi...
namespace WebUygulamaProje1.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {

        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }

        public DbSet<KitapTuru> kitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kiralama> Kiralamalar {  get; set; }
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
    }
}
