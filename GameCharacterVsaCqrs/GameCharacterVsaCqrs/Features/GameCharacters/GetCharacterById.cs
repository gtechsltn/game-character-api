using GameCharacterVsaCqrs.Data;
using GameCharacterVsaCqrs.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static GameCharacterVsaCqrs.Features.GameCharacters.GetCharacterById;

namespace GameCharacterVsaCqrs.Features.GameCharacters
{
    public static class GetCharacterById
    {
        public record Query(Guid Id) : IRequest<GameCharacter?>;

        public class Handler : IRequestHandler<Query, GameCharacter?>
        {
            private readonly DataContext _dbContext;

            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<GameCharacter?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.GameCharacters.FindAsync(request.Id);
            }
        }
    }

    [ApiController]
    [Route("api/characters")]
    public class GetCharacterByIdEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCharacterByIdEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var character = await _mediator.Send(new Query(id));
            return character != null ? Ok(character) : NotFound();
        }
    }
}
