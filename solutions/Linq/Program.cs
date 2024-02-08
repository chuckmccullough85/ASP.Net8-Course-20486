
using LinqApi;

Console.WriteLine("Welcome to the Movie Database");

var mdb = new MovieDb();
var m = mdb.Movies.Where(m => m.Cast.Contains("Anthony Hopkins"));
Console.WriteLine(m.First().Title);
foreach (var c in m.First().Cast)
    Console.WriteLine($"\t{c}");

m = mdb.Movies.Where(m => m.Cast.Contains("Anthony Hopkins")).OrderBy(m => m.Year);
Console.WriteLine($"First movie in {m.First().Year} was {m.First().Title} starring:");
foreach(var c in m.First().Cast) Console.WriteLine($"\t{c}");

Console.WriteLine($"Last movie in {m.Last().Year} was {m.Last().Title} starring:");
foreach (var c in m.Last().Cast) Console.WriteLine($"\t{c}");

var jnj = mdb.Movies
    .Where(m => m.Cast.Contains("John Wayne") && m.Cast.Contains("James Stewart"))
    .OrderBy(m => m.Year)
    .Select(m => (m.Year, m.Title));
Console.WriteLine("Movies with Stewart & Wayne");
foreach (var t in jnj) Console.WriteLine($"{t.Year} {t.Title}");

Console.WriteLine("G movies");
var gmov = mdb.Movies.Where (m=>m.Rated == "G")
    .OrderBy(m=>(m.Year, m.Title))
    .Select(m=> (m.Year, m.Title, star: m.Cast.FirstOrDefault()));
foreach(var t in gmov) Console.WriteLine($"{t.Year} {t.Title} \t starring {t.star}");
    
