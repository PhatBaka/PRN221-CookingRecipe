using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.DataModels
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
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ANAIS\\KELLION;Database=CookingRecipe;Trusted_Connection=True;");
            }
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

                entity.Property(e => e.NumberOfcalorie).HasColumnName("NumberOFCalorie");

                entity.HasOne(d => d.IngredientCategory)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IngredientCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_IngredientCategory");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.ToTable("IngredientCategory");

                entity.Property(e => e.IngredientCategoryId).HasColumnName("IngredientCategoryID");

                entity.Property(e => e.IngredientCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RecipeDetail>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.IngredientId });

                entity.ToTable("RecipeDetail");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

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
                entity.ToTable("Step");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

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
