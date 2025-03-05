using Application.DTOs;

namespace Application.Queries
{
    public class GetCharacterByIdQuery
    {
        private readonly IGameCharacterRepository _repository;

        public GetCharacterByIdQuery(IGameCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameCharacterDto?> Execute(Guid id)
        {
            var character = await _repository.GetByIdAsync(id);
            if (character == null) return null;

            return new GameCharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Class = character.Class,
                Level = character.Level
            };
        }
    }
}
