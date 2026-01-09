using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Services
{
    public interface IVideoGameCharacterServices
    {
        Task<List<GetCharacterResponseDto>> GetCharactersAsync();

        Task<GetCharacterResponseDto?> GetCharacterByIdAsync(int id);

        Task<GetCharacterResponseDto> AddCharacterAsync(Character character);

        Task<bool> UpdateCharacterAsync(int id, Character character);

        Task<bool> DeleteCharacterAsync(int id);

        //Lo que se hace en la interfaz es implementar las funciones que tendra la clase principal
    }
}
