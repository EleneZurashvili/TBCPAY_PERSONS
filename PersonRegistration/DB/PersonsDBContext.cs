using Microsoft.EntityFrameworkCore;
using PersonRegistration.Models;

namespace PersonRegistration.DB
{
    public class PersonsDBContext : DbContext
    {
        public PersonsDBContext(DbContextOptions<PersonsDBContext> options) : base(options) { }

        public DbSet<Person> People { get; private set; }

        public DbSet<City> Cities { get; private set; }
    }
}
