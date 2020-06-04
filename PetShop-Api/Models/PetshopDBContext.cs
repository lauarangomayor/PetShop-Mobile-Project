using Microsoft.EntityFrameworkCore;

namespace PetShop_Api.Models
{
    public class PetshopDBContext : DbContext
   {
    public PetshopDBContext(DbContextOptions<PetshopDBContext> options)
    : base(options)
    {
    }

    public DbSet<StateOrderModel> StatesOrder {get;set;}
    public DbSet<OrderModel> Orders {get;set;}
    public DbSet<AppointmentModel> Appointments{get;set;}
    public DbSet<AppointmentRecordModel> AppointmentsRecords{get;set;}
    public DbSet<CategoryModel> Categories{get;set;}
    public DbSet<Order_ProductsModel> Orders_Products{get;set;}
    public DbSet<OrderRecordModel> OrdersRecords{get;set;}
    public DbSet<PetModel> Pets{get;set;}
    public DbSet<ProductModel> Products{get;set;}
    public DbSet<SpecialtyModel> Specialties{get;set;}
    public DbSet<SpecieModel> Species{get;set;}
    public DbSet<StateProductModel> StatesProducts{get;set;}
    public DbSet<UserModel> Users{get;set;}
    public DbSet<ClientModel> Clients{get;set;}
    public DbSet<VeterinarianModel> Veterinarians{get;set;}
    public DbSet<WishList_ProductsModel> WishLists_Products{get;set;}
    public DbSet<WishListModel> WishLists{get;set;}
    public DbSet<Specialties_VetsModel> Specialties_Vets{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderModel>()
                    .HasOne(so => so.StateOrder)
                    .WithMany(o => o.Orders)
                    .HasForeignKey(so => so.IdStateOrder);
        
        modelBuilder.Entity<OrderModel>()
                    .HasOne(c => c.Client)
                    .WithMany(o => o.Orders)
                    .HasForeignKey(c => c.IdClient);

        modelBuilder.Entity<AppointmentModel>()
                    .HasOne(p => p.Pet)
                    .WithMany(a => a.Appointments)
                    .HasForeignKey(p => p.IdPet);

        modelBuilder.Entity<AppointmentModel>()
                    .HasOne(v => v.Veterinarian)
                    .WithMany(a => a.Appointments)
                    .HasForeignKey(v => v.IdVeterinarian);

        modelBuilder.Entity<Order_ProductsModel>()
                    .HasOne(p => p.Product)
                    .WithMany(op => op.Orders_Products)
                    .HasForeignKey(p => p.IdProduct);  

        modelBuilder.Entity<PetModel>()
                    .HasOne(c => c.Client)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(c => c.IdClient);

        modelBuilder.Entity<PetModel>()
                    .HasOne(s => s.Specie)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(s => s.IdSpecie);

        modelBuilder.Entity<ClientModel>()
                    .HasOne(u => u.User)
                    .WithMany(c => c.Clients)
                    .HasForeignKey(u => u.IdUser);

        modelBuilder.Entity<ProductModel>()
                    .HasOne(c => c.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(c => c.IdCategory);

        modelBuilder.Entity<ProductModel>()
                    .HasOne(sp => sp.StateProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(sp => sp.IdStateProduct);
        
        modelBuilder.Entity<Specialties_VetsModel>()
                    .HasOne(s => s.Specialty)
                    .WithMany(sv => sv.Specialties_Vets)
                    .HasForeignKey(s => s.IdSpecialty);

        modelBuilder.Entity<Specialties_VetsModel>()
                    .HasOne(s => s.Veterinarian)
                    .WithMany(sv => sv.Specialties_Vets)
                    .HasForeignKey(s => s.IdVeterinarian);
        
        modelBuilder.Entity<VeterinarianModel>()
                    .HasOne(u => u.User)
                    .WithMany(v => v.Veterinarians)
                    .HasForeignKey(u => u.IdUser);
        
        modelBuilder.Entity<WishList_ProductsModel>()
                    .HasOne(w => w.WishList)
                    .WithMany(wp => wp.WishLists_Products)
                    .HasForeignKey(w => w.IdWishList);
                    
        modelBuilder.Entity<WishList_ProductsModel>()
                    .HasOne(w => w.Product)
                    .WithMany(wp => wp.WishLists_Products)
                    .HasForeignKey(w => w.IdProduct);

        modelBuilder.Entity<WishListModel>()
                    .HasOne(c => c.Client)
                    .WithMany(w => w.WishLists)
                    .HasForeignKey(c => c.IdClient);
    }

   }

}