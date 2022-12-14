// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeVault.Data;

#nullable disable

namespace RecipeVault.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220911194919_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("RecipeVault.Models.Recipes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("image_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ingredients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("time")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
