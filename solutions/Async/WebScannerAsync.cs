namespace TasksSolution
{
    public class WebScannerAsync
    {
        public record KeywordResults(string Url, string Keyword, int Count);
        public IEnumerable<string> Keywords { get; set; } = new List<string>();
        public IEnumerable<string> Urls { get; set; } = new List<string>();
        private async Task<KeywordResults> GetKeywordCount(string url, string keyword)
        {
            return await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var text = await response.Content.ReadAsStringAsync();
                int count = 0; int idx = 0;
                while ((idx = text.IndexOf(keyword, idx + 1)) > -1)
                    count++;
                return new KeywordResults(url, keyword, count);
            });
        }
        public async Task<IEnumerable<KeywordResults>> Go()
        {
            Console.WriteLine($"Go started on thread {Thread.CurrentThread.ManagedThreadId}");
            var list = new List<KeywordResults>();
            var tasks = new List<Task<KeywordResults>>();
            foreach (var url in Urls)
                foreach (var key in Keywords)
                    tasks.Add(GetKeywordCount(url, key));
            while (tasks.Count > 0)
            {
                var t = await Task.WhenAny(tasks);
                Console.WriteLine($"Go: web task finished on  {Thread.CurrentThread.ManagedThreadId}");
                tasks.Remove(t);
                list.Add(t.Result);
            }
            
            return list;
        }
    }
}
