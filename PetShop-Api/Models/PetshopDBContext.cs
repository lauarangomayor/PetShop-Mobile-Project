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
    public DbSet<AppointmentRecord> AppointmentsRecords{get;set;}
    public DbSet<CategoryModel> Categories{get;set;}
    public DbSet<Order_ProductsModel> Orders_Products{get;set;}
    public DbSet<OrderRecordModel> OrdersRecords{get;set;}
    public DbSet<PetModel> Pets{get;set;}
    public DbSet<ProductModel> Products{get;set;}
    public DbSet<SpecialtyModel> Specialties{get;set;}
    public DbSet<SpecieModel> Species{get;set;}
    public DbSet<StateProductModel> StatesProducts{get;set;}
    public DbSet<UserModel> Users{get;set;}
    public DbSet<VeterinarianModel> Veterinarians{get;set;}
    public DbSet<WishList_ProductsModel> WishLists_Products{get;set;}
    public DbSet<WishListModel> WishLists{get;set;}
    public DbSet<Specialties_VetsModel> Specialties_Vets{get;set;}

   }

}