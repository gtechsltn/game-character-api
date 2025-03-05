using GameCharacterVsaCqrs.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCharacterVsaCqrs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GameCharacter> GameCharacters { get; set; }
    }
}
