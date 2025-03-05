using GameCharacterService.Entities;

namespace GameCharacterService.Services
{
    public interface IGameCharacterService
    {
        Task<List<GameCharacter>> GetAllCharactersAsync();
        Task<GameCharacter?> GetCharacterByIdAsync(Guid id);
        Task<GameCharacter> CreateCharacterAsync(GameCharacter character);
        Task<GameCharacter?> UpdateCharacterAsync(GameCharacter character);
        Task<bool> DeleteCharacterAsync(Guid id);
        Task<bool> LevelUpCharacterAsync(Guid id);
    }
}
