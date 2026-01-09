using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Database;
using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Services
{
    //En esta clase heredaremos los metodos o implementaciones que tenga la interfaz del personaje
    public class VideoGameCharacterServices(AppDBContext context) : IVideoGameCharacterServices
    {

        static List<Character> characters = new List<Character> {
            new Character{ Id=1,Name="Mario",Class="Hero",Game="Super Mario Bros"},
            new Models.Character {Id=2,Name="Link",Class="Hero",Game="The Legend of Zelda"},
            new Models.Character {Id=3,Name="Bowser",Class="Villain",Game="Super Mario Bros"},

        };

        public async Task<GetCharacterResponseDto> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetCharacterResponseDto?> GetCharacterByIdAsync(int id)
        {
            //Expresio lambda que funciona para retornar un valor que coindice con las especificaciones
            //En los parentesis, en este caso queremos un c (character) cuyo character id sea igual
            //Al agregado en los parametros al usar el metodo
            var results = await context.Characters.Where(c => c.Id == id).Select(c => new GetCharacterResponseDto
            {
                Name = c.Name,
                Class = c.Class,
                Game = c.Game,

            }).FirstOrDefaultAsync();
            return results;
                            
            
            
        }

        public async Task<List<GetCharacterResponseDto>> GetCharactersAsync() =>
        await context.Characters.Select(c=> new GetCharacterResponseDto{
            
            Name= c.Name,
            Game=c.Game,
            Class=c.Class
            }).ToListAsync();

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
