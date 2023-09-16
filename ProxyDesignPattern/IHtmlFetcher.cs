



namespace HtmlFetcherApp.Interfaces
{
    public interface IHtmlFetcher
    {
        Task<string> GetHtmlContentAsync( string url );
    }
}
