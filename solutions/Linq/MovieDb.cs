using System.Text.Json;

namespace LinqApi
{
    public record Movie (string Title, int Year, string Rated, string Genre, string[] Cast );
    public class MovieDb
    {
        public MovieDb()
        {
            var movies = new List<Movie>();
            Movies = movies; 
            using var rdr = new StreamReader("ReducedMoviesJson.txt");
            string? line;
            while ((line = rdr.ReadLine()) != null) 
            {
                var m = JsonSerializer.Deserialize<Movie>(line);
                if (m != null) movies.Add(m);
            }
        }
        public IEnumerable<Movie> Movies { get; init; }
    }
}
