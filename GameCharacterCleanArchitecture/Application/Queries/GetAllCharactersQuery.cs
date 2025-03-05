using Application.DTOs;

namespace Application.Queries
{
    public class GetAllCharactersQuery
    {
        private readonly IGameCharacterRepository _repository;

        public GetAllCharactersQuery(IGameCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GameCharacterDto>> Execute()
        {
            var characters = await _repository.GetAllAsync();
            return characters.Select(character => new GameCharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Class = character.Class,
                Level = character.Level
            }).ToList();
        }
    }
}
