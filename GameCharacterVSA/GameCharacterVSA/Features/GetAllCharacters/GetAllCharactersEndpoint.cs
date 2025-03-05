using GameCharacterVSA.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCharacterVSA.Features.GetAllCharacters
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllCharactersEndpoint : ControllerBase
    {
        private readonly DataContext _dbContext;

        public GetAllCharactersEndpoint(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var characters = await _dbContext.GameCharacters.ToListAsync();
            return Ok(characters);
        }
    }
}
