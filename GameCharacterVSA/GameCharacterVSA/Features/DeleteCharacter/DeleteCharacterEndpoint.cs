using GameCharacterVSA.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameCharacterVSA.Features.DeleteCharacter
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCharacterEndpoint : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DeleteCharacterEndpoint(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var character = await _dbContext.GameCharacters.FindAsync(id);
            if (character == null) return NotFound();

            _dbContext.GameCharacters.Remove(character);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
