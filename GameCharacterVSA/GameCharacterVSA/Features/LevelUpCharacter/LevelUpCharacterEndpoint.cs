using GameCharacterVSA.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameCharacterVSA.Features.LevelUpCharacter
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelUpCharacterEndpoint : ControllerBase
    {
        private readonly DataContext _dbContext;

        public LevelUpCharacterEndpoint(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPatch("{id}/level-up")]
        public async Task<IActionResult> LevelUp(Guid id)
        {
            var character = await _dbContext.GameCharacters.FindAsync(id);
            if (character == null) return NotFound();

            character.Level++;
            await _dbContext.SaveChangesAsync();

            return Ok(new { Message = "Character leveled up successfully!" });
        }
    }
}
