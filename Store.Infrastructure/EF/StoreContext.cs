using System;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;

namespace Store.Infrastructure.EF
{
    public class PassengerContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> User {get;set;}
        public PassengerContext(DbContextOptions<PassengerContext> options, SqlSettings sqlSettings) : base(options)
        {
            _sqlSettings =sqlSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("storeTest");

                return;
            }
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 22));
            optionsBuilder.UseMySql(_sqlSettings.ConnectionString,serverVersion)
                         .EnableSensitiveDataLogging()
                         .EnableDetailedErrors();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);
            userBuilder.HasMany(u => u.UserTransactions)
                       .WithOne(ut => ut.User);                       

            var gameBuilder = modelBuilder.Entity<Game>();
            gameBuilder.HasKey(g => g.Id);            
            gameBuilder.HasOne(g => g.Platform)
                        .WithMany(p => p.Games)
                        .HasForeignKey(g => g.PlatformId);
                       
            var platformBuilder = modelBuilder.Entity<Platform>();
            platformBuilder.HasKey(p => p.Id);

            var gameCategoryBuilder = modelBuilder.Entity<GameCategory>();
            gameCategoryBuilder.HasKey(gc => gc.Id);
            gameCategoryBuilder.HasOne(gc => gc.Game)
                                .WithMany(g => g.GameCategories)
                                .HasForeignKey(gc => gc.GameId);
            gameCategoryBuilder.HasOne(gc => gc.Category)
                                .WithMany(c => c.GameCategories)
                                .HasForeignKey(gc => gc.CategoryId);
            var keyBuilder = modelBuilder.Entity<Key>();
            keyBuilder.HasKey(k => k.Id);
            keyBuilder.HasOne(k => k.Game)
                      .WithMany(g => g.Keys)
                      .HasForeignKey(k => k.GameId);
            


           
        }
    }
}