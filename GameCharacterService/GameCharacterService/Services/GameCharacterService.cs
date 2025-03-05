using GameCharacterService.Entities;
using GameCharacterService.Repositories;

namespace GameCharacterService.Services
{
    public class GameCharacterService : IGameCharacterService
    {
        private readonly IGameCharacterRepository _repository;

        public GameCharacterService(IGameCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GameCharacter>> GetAllCharactersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GameCharacter?> GetCharacterByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<GameCharacter> CreateCharacterAsync(GameCharacter character)
        {
            return await _repository.AddAsync(character);
        }

        public async Task<GameCharacter?> UpdateCharacterAsync(GameCharacter character)
        {
            return await _repository.UpdateAsync(character);
        }

        public async Task<bool> DeleteCharacterAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> LevelUpCharacterAsync(Guid id)
        {
            return await _repository.LevelUpAsync(id);
        }
    }
}
