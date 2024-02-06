## Overview
---
In this exercise, we will scan websites looking for keywords.  Our scanner provides 2 properties to hold the keywords and the urls to sclan.
The code below contains synchronous execution.

| | |
| --------- | --------------------------- |
| Exercise Folder | Tasks |
| Builds On | none |
| Time to complete | 30 minutes


1. Create a new console application.
1. Create a new class named WebScannerSync.and paste the code below.
1. In Program.cs, create an instance and set some strings in the keywords list and websites in the url list
1. Call Go and loop through displaying the results.
1. Now, modify the WebScanner to use Tasks.  Each URL/Keyword combination can be specified as a task. 
1. In Go, wait for all the tasks to complete  (see Task.WaitAll)

```C#
public class WebScannerSync
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
    public IEnumerable<KeywordResults> Go()
    {
        var list = new List<KeywordResults>();
        foreach (var url in Urls)
            foreach (var key in Keywords)
                list.Add(GetKeywordCount(url, key));
        return list;
    }
}
```

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/Tasks)