using GameCharacterVsaCqrs.Data;
using GameCharacterVsaCqrs.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GameCharacterVsaCqrs.Features.GameCharacters.CreateCharacter;

namespace GameCharacterVsaCqrs.Features.GameCharacters
{
    public static class CreateCharacter
    {
        public record Command(string Name, string Class) : IRequest<GameCharacter>;

        public class Handler : IRequestHandler<Command, GameCharacter>
        {
            private readonly DataContext _dbContext;

            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<GameCharacter> Handle(Command request, CancellationToken cancellationToken)
            {
                var character = new GameCharacter
                {
                    Name = request.Name,
                    Class = request.Class,
                    Level = 1
                };

                _dbContext.GameCharacters.Add(character);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return character;
            }
        }
    }

    [ApiController]
    [Route("api/characters")]
    public class CreateCharacterEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateCharacterEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Command command)
        {
            var character = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = character.Id }, character);
        }
    }
}
