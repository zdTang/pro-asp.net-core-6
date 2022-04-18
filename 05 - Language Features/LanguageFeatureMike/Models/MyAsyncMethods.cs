﻿namespace LanguageFeatureMike.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");
            return httpTask.ContinueWith(
                (Task<HttpResponseMessage> antecedent) =>
                {
                    return antecedent.Result.Content.Headers.ContentLength;   
                });

        }

        // using ASYNC and AWAIT
        public async static Task<long?> GetPageLengthTwo()
        {
            HttpClient client = new HttpClient();
            var httpTask = await client.GetAsync("http://apress.com");
            return httpTask.Content.Headers.ContentLength;        
        }


        public static async Task<IEnumerable<long?>> GetPageLengths(List<string> output, params string[] urls)
        {
            List<long?> results = new List<long?>();
            HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                results.Add(httpMessage.Content.Headers.ContentLength);
                output.Add($"Completed request for {url}");
            }
            return results;
        }
        // THIS ONE WILL RETURN RESULT ONE AFTER ANOTHER
        // The return type is IAsyncEnumerable !!! 
        public static async IAsyncEnumerable<long?> GetPageLengthsEach(List<string> output, params string[] urls)
        {
            //List<long?> results = new List<long?>();
            HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                output.Add($"Completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }
            
        }
    }
}
