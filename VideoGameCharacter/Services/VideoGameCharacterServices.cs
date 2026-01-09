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

        public async Task<GetCharacterResponseDto> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newcharacters = new Character
            {
                Name = character.Name,
                Class = character.Class,
                Game = character.Game,
            };
            context.Characters.Add(newcharacters);
            await context.SaveChangesAsync();
            return new GetCharacterResponseDto
            {
                Id = newcharacters.Id,
                Name = newcharacters.Name,
                Class = newcharacters.Class,
                Game = newcharacters.Game
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var deleteCharacter = await context.Characters.FindAsync(id);
            if (deleteCharacter is null) return false;
            
            context.Characters.Remove(deleteCharacter);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<GetCharacterResponseDto?> GetCharacterByIdAsync(int id)
        {
            //Expresio lambda que funciona para retornar un valor que coindice con las especificaciones
            //En los parentesis, en este caso queremos un c (character) cuyo character id sea igual
            //Al agregado en los parametros al usar el metodo
            var results = await context.Characters.Where(c => c.Id == id).Select(c => new GetCharacterResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Class = c.Class,
                Game = c.Game,

            }).FirstOrDefaultAsync();
            return results;
                            
            
            
        }

        public async Task<List<GetCharacterResponseDto>> GetCharactersAsync() =>
        await context.Characters.Select(c=> new GetCharacterResponseDto{
            Id = c.Id,
            Name= c.Name,
            Game=c.Game,
            Class=c.Class
            }).ToListAsync();

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null) return false;
            existingCharacter.Name = character.Name;
            existingCharacter.Class = character.Class;
            existingCharacter.Game = character.Game;
            await context.SaveChangesAsync();
            return true;


        }
    }
}
