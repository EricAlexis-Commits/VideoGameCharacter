using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;
using VideoGameCharacter.Services;

namespace VideoGameCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterController(IVideoGameCharacterServices services) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<GetCharacterResponseDto>>> GetCharacters() =>
            Ok(await services.GetCharactersAsync());

        [HttpGet("{id}")]

        public async Task<ActionResult<List<GetCharacterResponseDto>>> GetCharacter(int id) {
            var character = await services.GetCharacterByIdAsync(id);
            if (character is null) {
                return NotFound("Character with the given Id was not found");
            }
            return Ok(character);
        }

    }
}
