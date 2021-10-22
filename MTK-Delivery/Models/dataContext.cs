using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class dataContext:DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<DriverHistory> driverHistories { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<FoodContent> foodContents { get; set; }
        public DbSet<functionality> functionalities { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<RestaurantStatus> restaurantStatuses { get; set; }
        public DbSet<OrderStatus> orderStatuses { get; set; }
        public DbSet<Status> statuses { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(b => b._LocationId).HasColumnName("LocationId");
            modelBuilder.Entity<Order>()
                .Property(b => b._location).HasColumnName("location");
            modelBuilder.Entity<Restaurant>()
            .Property(b => b._categoryId).HasColumnName("category");
            modelBuilder.Entity<Restaurant>()
                .Property(b => b._location).HasColumnName("location");
        }
    }
}
