

// Importing the interface's namespace
using HtmlFetcherApp.Interfaces; 


namespace HtmlFetcherApp.Implementations
{
    public class RealHtmlFetcher : IHtmlFetcher
    {
        private readonly HttpClient _httpClient;

        public RealHtmlFetcher()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetHtmlContentAsync( string url )
        {
            //for checking if the string has white spaces or string is null
            if (string.IsNullOrWhiteSpace( url ))
            {
                throw new ArgumentException( "URL cannot be empty or whitespace." , nameof( url ) );
            }
            //getting content from main server
            string htmlContent = await _httpClient.GetStringAsync( url );
            return htmlContent;
        }
    }
}
