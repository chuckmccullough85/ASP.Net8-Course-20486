namespace TasksSolution;

public class WebScannerTask
{
    public record KeywordResults(string Url, string Keyword, int Count);
    public IEnumerable<string> Keywords { get; set; } = new List<string>();
    public IEnumerable<string> Urls { get; set; } = new List<string>();
    private KeywordResults GetKeywordCount(string url, string keyword)
    {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var text = response.Content.ReadAsStringAsync().Result;
            int count = 0; int idx = 0;
            while ((idx = text.IndexOf(keyword, idx + 1)) > -1)
                count++;
            return new KeywordResults(url, keyword, count);
    }
    public  IEnumerable<KeywordResults> Go()
    {
        var list = new List<KeywordResults>();
        var tasks = new List<Task<KeywordResults>>();
        foreach (var url in Urls)
            foreach (var key in Keywords)
                tasks.Add(Task.Run(()=>GetKeywordCount(url, key)));
        
        while (tasks.Count > 0)
        {
            var t = Task.WhenAny(tasks).Result;
            tasks.Remove(t);
            list.Add(t.Result);
            Console.WriteLine($"Getting Results with thread {Thread.CurrentThread.ManagedThreadId}");
        }

        return list;
    }
}
