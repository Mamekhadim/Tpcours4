using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TPCOUR5.Models;

namespace TPCOUR5
{
	public class ApplicationDBContext:IdentityDbContext<IdentityUser>
	{
		//Creation du constructeur
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
		

		public virtual DbSet<Category>Categories { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Marque> Marques { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>()
				.HasOne(p => p.Category)
				.WithMany(p => p.Products)
				.HasForeignKey(pro => pro.CategoryId);


			modelBuilder.Entity<Product>()
				.HasOne(p => p.Marque)
				.WithMany(p => p.Products)
				.HasForeignKey(pro => pro.MarqueId);

			modelBuilder.Entity<Product>()
				.Property(p => p.price)
				.HasColumnType("decimal(8.2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasColumnType("decimal(8.2)");





        }


    }	
}
