using GameCharacterVSA.Data;
using GameCharacterVSA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameCharacterVSA.Features.CreateCharacter
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateCharacterEndpoint : ControllerBase
    {
        private readonly DataContext _dbContext;

        public CreateCharacterEndpoint(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCharacterRequest request)
        {
            var character = new GameCharacter
            {
                Name = request.Name,
                Class = request.Class,
                Level = 1
            };

            _dbContext.GameCharacters.Add(character);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = character.Id }, character);
        }
    }
}
