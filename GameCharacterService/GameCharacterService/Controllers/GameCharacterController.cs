using GameCharacterService.Entities;
using GameCharacterService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameCharacterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCharacterController : ControllerBase
    {
        private readonly IGameCharacterService _characterService;

        public GameCharacterController(IGameCharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null) return NotFound();
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameCharacter character)
        {
            var createdCharacter = await _characterService.CreateCharacterAsync(character);
            return CreatedAtAction(nameof(GetById), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GameCharacter character)
        {
            if (id != character.Id) return BadRequest();

            var updatedCharacter = await _characterService.UpdateCharacterAsync(character);
            if (updatedCharacter == null) return NotFound();

            return Ok(updatedCharacter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _characterService.DeleteCharacterAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpPatch("{id}/level-up")]
        public async Task<IActionResult> LevelUp(Guid id)
        {
            var success = await _characterService.LevelUpCharacterAsync(id);
            if (!success) return NotFound();

            return Ok(new { Message = "Character leveled up successfully!" });
        }
    }
}
