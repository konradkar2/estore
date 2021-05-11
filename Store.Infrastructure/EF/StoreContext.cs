using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Store.Core.Domain;

namespace Store.Infrastructure.EF
{
    public class StoreContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> User {get;set;}
        public DbSet<Platform> Platform{get;set;}
        public DbSet<Game> Game{get;set;}
        public DbSet<GameCategory> GameCategory{get;set;}
        public DbSet<GameTransaction> GameTransaction{get;set;}
        public DbSet<Category> Category {get;set;}
        public DbSet<UserTransaction> UserTransaction {get;set;}
        public DbSet<Key> Key {get;set;}
        public StoreContext(DbContextOptions<StoreContext> options, SqlSettings sqlSettings) : base(options)
        {
            _sqlSettings =sqlSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("storeTest");
                optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
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
            userBuilder.HasKey(u => u.Id);

            var userTransactionBuilder = modelBuilder.Entity<UserTransaction>();
            userTransactionBuilder.HasKey(ut => ut.Id);       
            userTransactionBuilder.HasOne(ut => ut.User)
                                  .WithMany(u => u.UserTransactions)
                                  .HasForeignKey(ut => ut.UserId);

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
            var keyBuilder = modelBuilder.Entity<Key>().ToTable("GameKey");            
            keyBuilder.HasKey(k => k.Id);
            keyBuilder.HasOne(k => k.Game)
                      .WithMany(g => g.Keys)
                      .HasForeignKey(k => k.GameId);
            keyBuilder.HasOne(k => k.GameTransaction)
                      .WithOne(gt => gt.Key)
                      .HasForeignKey<GameTransaction>(gt => gt.KeyId);

            var categoryBuilder = modelBuilder.Entity<Category>();
            categoryBuilder.HasKey(c => c.Id);

            var gameTransactionBuilder = modelBuilder.Entity<GameTransaction>();
            gameTransactionBuilder.HasKey(gt => gt.Id);
            gameTransactionBuilder.HasOne(gt => gt.UserTransaction)
                                  .WithMany(ut => ut.GameTransactions)
                                  .HasForeignKey(gt => gt.UserTransactionId);
           
                                 
                                                                   
                                

           
            


           
        }
    }
}