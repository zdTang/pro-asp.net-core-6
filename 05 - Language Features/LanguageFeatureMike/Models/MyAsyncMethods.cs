namespace LanguageFeatureMike.Models
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
    }
}
