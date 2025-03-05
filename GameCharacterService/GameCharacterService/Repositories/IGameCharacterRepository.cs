using GameCharacterService.Entities;

namespace GameCharacterService.Repositories
{
    public interface IGameCharacterRepository
    {
        Task<List<GameCharacter>> GetAllAsync();
        Task<GameCharacter?> GetByIdAsync(Guid id);
        Task<GameCharacter> AddAsync(GameCharacter character);
        Task<GameCharacter?> UpdateAsync(GameCharacter character);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> LevelUpAsync(Guid id);
    }
}
