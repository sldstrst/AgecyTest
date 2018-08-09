using System.Data.Entity;


namespace Agent.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() :
            base("AgentstvoDb")
        { }
        public DbSet<Person> People { get; set; }

        public DbSet<Post> Posts { get; set; }

       // public DbSet<Apartament> Apartaments { get; set; }
    }
}