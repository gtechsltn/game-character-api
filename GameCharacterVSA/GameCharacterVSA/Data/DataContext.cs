using GameCharacterVSA.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCharacterVSA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GameCharacter> GameCharacters { get; set; }
    }
}
