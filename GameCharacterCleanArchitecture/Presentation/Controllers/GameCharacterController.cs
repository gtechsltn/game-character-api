using Application;
using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCharacterController : ControllerBase
    {
        private readonly IGameCharacterRepository _characterRepository;

        public GameCharacterController(IGameCharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameCharacterDto request)
        {
            var useCase = new CreateCharacterCommand(_characterRepository);
            var character = await useCase.Execute(request.Name, request.Class);
            return CreatedAtAction(nameof(GetById), new { id = character.Id }, character);
        }

        [HttpPatch("{id}/level-up-with-repository")]
        public async Task<IActionResult> LevelUpWithRepository(Guid id)
        {
            var success = await _characterRepository.LevelUpAsync(id);
            if (!success) return NotFound();
            return Ok(new { Message = "Character leveled up successfully!" });
        }

        [HttpPatch("{id}/level-up")]
        public async Task<IActionResult> LevelUp(Guid id)
        {
            var useCase = new LevelUpCharacterCommand(_characterRepository);
            var success = await useCase.Execute(id);
            if (!success) return NotFound();
            return Ok(new { Message = "Character leveled up successfully!" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var useCase = new GetCharacterByIdQuery(_characterRepository);
            var character = await useCase.Execute(id);
            if (character == null) return NotFound();
            return Ok(character);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllCharactersQuery(_characterRepository);
            var characters = await useCase.Execute();
            return Ok(characters);
        }
    }
}
