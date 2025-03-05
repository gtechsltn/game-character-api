using GameCharacterVSA.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameCharacterVSA.Features.GetCharacterById
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCharacterByIdEndpoint : ControllerBase
    {
        private readonly DataContext _dbContext;

        public GetCharacterByIdEndpoint(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var character = await _dbContext.GameCharacters.FindAsync(id);
            return character != null ? Ok(character) : NotFound();
        }
    }
}
