namespace Application.Commands
{
    public class LevelUpCharacterCommand
    {
        private readonly IGameCharacterRepository _repository;

        public LevelUpCharacterCommand(IGameCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(Guid id)
        {
            return await _repository.LevelUpAsync(id);
        }
    }
}
