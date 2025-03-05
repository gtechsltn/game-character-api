using GameCharacterVsaCqrs.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GameCharacterVsaCqrs.Features.GameCharacters.LevelUpCharacter;

namespace GameCharacterVsaCqrs.Features.GameCharacters
{
    public static class LevelUpCharacter
    {
        public record Command(Guid Id) : IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly DataContext _dbContext;

            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = await _dbContext.GameCharacters.FindAsync(request.Id);
                if (character == null) return false;

                character.Level++;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }

    [ApiController]
    [Route("api/characters")]
    public class LevelUpCharacterEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public LevelUpCharacterEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("{id}/level-up")]
        public async Task<IActionResult> LevelUp(Guid id)
        {
            var success = await _mediator.Send(new Command(id));
            return success ? Ok(new { Message = "Character leveled up!" }) : NotFound();
        }
    }
}
