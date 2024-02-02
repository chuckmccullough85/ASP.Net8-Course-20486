using TasksSolution;

WebScannerTask scanner = new();
scanner.Keywords = new string[] { "Help", "Home", "Index", "Top", "2023", "C#", "C++", "Security", ".Net", "Microsoft", "Privacy", "Terms", "Profit" };
scanner.Urls = new string[] { 
    "https://learn.microsoft.com/en-us/dotnet/csharp/", 
    "https://www.mcculloughassociates.com",
    "https://learn.microsoft.com/en-us/dotnet/csharp/",
    "https://www.mcculloughassociates.com",
    "https://learn.microsoft.com/en-us/dotnet/csharp/",
    "https://www.mcculloughassociates.com",
    "https://trainmyprogrammers.com",
    "https://www.udemy.com"
};
var results = await scanner.Go();
foreach (var r in results)
    Console.WriteLine(r);


