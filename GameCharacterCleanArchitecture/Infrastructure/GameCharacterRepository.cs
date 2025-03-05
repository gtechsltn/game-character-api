using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GameCharacterRepository : IGameCharacterRepository
    {
        private readonly DataContext _context;

        public GameCharacterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GameCharacter>> GetAllAsync() => await _context.GameCharacters.ToListAsync();

        public async Task<GameCharacter?> GetByIdAsync(Guid id) => await _context.GameCharacters.FindAsync(id);

        public async Task<GameCharacter> AddAsync(GameCharacter character)
        {
            _context.GameCharacters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<bool> LevelUpAsync(Guid id)
        {
            var character = await _context.GameCharacters.FindAsync(id);
            if (character == null) return false;

            character.Level++;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var character = await _context.GameCharacters.FindAsync(id);
            if (character == null) return false;

            _context.GameCharacters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
