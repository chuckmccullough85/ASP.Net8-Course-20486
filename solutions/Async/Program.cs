using TasksSolution;
using static System.Net.WebRequestMethods;

WebScannerAsync scanner = new();
scanner.Keywords = new string[] { "C#", "C++", "Security", "Java", "Programmer", "Cobol", "Basic" };
scanner.Urls = new string[] { 
    "https://learn.microsoft.com/en-us/dotnet/csharp/", 
    "https://www.mcculloughassociates.com",
    "https://en.wikipedia.org/wiki/Programming_language",
    "https://trainmyprogrammers.com",
    "https://en.wikipedia.org/wiki/Formal_language",
    "https://en.wikipedia.org/wiki/Computer_science",
    "https://en.wikipedia.org/wiki/Vulnerability_(computing)",
    "https://www.udemy.com/course/getting-started-in-cpp/",
    "https://www.udemy.com/course/intermediate-csharp/"
};

var results = await scanner.Go();
foreach (var r in results)
    Console.WriteLine(r);
