

// Import the interface's namespace
using HtmlFetcherApp.Interfaces; 


namespace HtmlFetcherApp.Implementations
{
    public class HtmlFetcherProxy : IHtmlFetcher
    {
        private readonly RealHtmlFetcher _realHtmlFetcher = new();

        public async Task<string> GetHtmlContentAsync( string url )
        {
            if (string.IsNullOrWhiteSpace( url ))
            {
                throw new ArgumentException( "URL cannot be empty or whitespace." , nameof( url ) );
            }
            // Checking if the html content is cached in the memory or not
            if (Program.cache.ContainsKey( url ))
            {
                Console.WriteLine( "Fetched HTML content from cache." );
                return Program.cache[url];
            }
            //if not fetch it from the main server
            else
            {
                
                string htmlContent = await _realHtmlFetcher.GetHtmlContentAsync( url );

                //Store  the HTML content in memory
                Program.cache[url] = htmlContent;
                Console.WriteLine( "Fetched HTML content from the main server and cached it." );
                //return the html content
                return htmlContent;
            }
        }
    }
}
