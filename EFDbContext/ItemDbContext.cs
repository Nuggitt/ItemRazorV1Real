﻿using ItemRazorV1Real.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemRazorV1Real.EFDbContext
{
    public class ItemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ItemDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}