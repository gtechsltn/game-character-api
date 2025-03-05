using Domain;

namespace Application.Commands
{
    public class CreateCharacterCommand
    {
        private readonly IGameCharacterRepository _repository;

        public CreateCharacterCommand(IGameCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameCharacter> Execute(string name, string characterClass)
        {
            var character = new GameCharacter { Name = name, Class = characterClass, Level = 1 };
            return await _repository.AddAsync(character);
        }
    }
}
