using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Database
{
    public class AppDBContext(DbContextOptions<AppDBContext>options) : DbContext(options)
    {
        //Esta instancia es usada para guardar y buscar consultas con formato LINQ en una base de datos
        //En este caso estamos indicando que se creara una especie de tabla con los personajes con respecto
        //a la clase Character.
        public DbSet<Character> Characters => Set<Character>();
    }
}
