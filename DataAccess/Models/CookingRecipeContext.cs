using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataAccess.Models
{
    public partial class CookingRecipeContext : DbContext
    {
        public CookingRecipeContext()
        {
        }

        public CookingRecipeContext(DbContextOptions<CookingRecipeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientCaloriesPerUnit> IngredientCaloriesPerUnits { get; set; }
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
        public virtual DbSet<IngredientUnit> IngredientUnits { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealCategory> MealCategories { get; set; }
        public virtual DbSet<MealDetail> MealDetails { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Step> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true,reloadOnChange:true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasColumnType("image");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.TimeJoined).HasColumnType("date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RecipeId });

                entity.ToTable("Favorite");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.TimeUpdated).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorite_Account");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorite_Recipe");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.IngredientCategoryId).HasColumnName("IngredientCategoryID");

                entity.HasOne(d => d.IngredientCategory)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IngredientCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_IngredientCategory");
            });

            modelBuilder.Entity<IngredientCaloriesPerUnit>(entity =>
            {
                entity.HasKey(e => new { e.IngredientId, e.UnitId });

                entity.ToTable("IngredientCaloriesPerUnit");

                entity.Property(e => e.IngredientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IngredientID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.CaloriesPerUnit).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientCaloriesPerUnits)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientCaloriesPerUnit_Ingredient");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.IngredientCaloriesPerUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientCaloriesPerUnit_IngredientUnit");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.ToTable("IngredientCategory");

                entity.Property(e => e.IngredientCategoryId).HasColumnName("IngredientCategoryID");

                entity.Property(e => e.IngredientCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IngredientUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__Ingredie__44F5EC95C9742AB7");

                entity.ToTable("IngredientUnit");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meal");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.MealCategoryId).HasColumnName("MealCategoryID");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_Account");

                entity.HasOne(d => d.MealCategory)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_MealCategory");
            });

            modelBuilder.Entity<MealCategory>(entity =>
            {
                entity.ToTable("MealCategory");

                entity.Property(e => e.MealCategoryId).HasColumnName("MealCategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MealDetail>(entity =>
            {
                entity.HasKey(e => new { e.MealId, e.RecipeId });

                entity.ToTable("MealDetail");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MealDetails)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MealDetail_Meal");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.MealDetails)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MealDetail_Recipe");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RecipeId });

                entity.ToTable("Rating");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CommentContent).IsRequired();

                entity.Property(e => e.TimeUpdated).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Account");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Recipe");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Account");
            });

            modelBuilder.Entity<RecipeDetail>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.IngredientId });

                entity.ToTable("RecipeDetail");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeDetails)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeDetail_Ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeDetails)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecipeDetail_Recipe");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.RecipeDetails)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_RecipeDetail_IngredientUnit");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasKey(e => new { e.StepIndex, e.RecipeId });

                entity.ToTable("Step");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Recipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
