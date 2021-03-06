// <auto-generated />
using System;
using CookBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CookBook.Migrations
{
    [DbContext(typeof(CookBookContext))]
    [Migration("20220111195012_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CookBook.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("CookBook.Models.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Measure");
                });

            modelBuilder.Entity("CookBook.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("CookingTime")
                        .HasColumnType("time");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("CookBook.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("Recipe_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Ammount")
                        .HasColumnType("float");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int?>("MeasureId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Recipe_id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MeasureId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("CookBook.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CookBook.Models.Recipe", b =>
                {
                    b.HasOne("CookBook.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("CookBook.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CookBook.Models.RecipeIngredient", b =>
                {
                    b.HasOne("CookBook.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.HasOne("CookBook.Models.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureId");

                    b.HasOne("CookBook.Models.Recipe", null)
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Ingredient");

                    b.Navigation("Measure");
                });

            modelBuilder.Entity("CookBook.Models.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
