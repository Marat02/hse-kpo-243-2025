using KPO.CarPreOrder.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPO.CarPreOrder.Infrastructure;

public class CarPreOrderDbContext : DbContext
{
    public DbSet<CarModel> Cars { get; set; }
    
    public CarPreOrderDbContext(DbContextOptions<CarPreOrderDbContext> options) : base(options)
    {
    }
}