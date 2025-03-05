using Domain;

namespace Application
{
    public interface IGameCharacterRepository
    {
        Task<List<GameCharacter>> GetAllAsync();
        Task<GameCharacter?> GetByIdAsync(Guid id);
        Task<GameCharacter> AddAsync(GameCharacter character);
        Task<bool> LevelUpAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
