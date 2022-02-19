using HouseFinder.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder.Data
{
    public class HouseFinderDbContext : DbContext
    {
        public HouseFinderDbContext(DbContextOptions<HouseFinderDbContext> options) : base(options)
        {

        }

        public DbSet<CriteriaDto> Criteria { get; set; }
        public DbSet<PropertyDto> Property { get; set; }
    }
}
