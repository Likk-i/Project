using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlFetcherApp.Interfaces;
using HtmlFetcherApp.Implementations;

public class Program
{
    // Declare a cache for storing HTML content with URL as the key and HTML content as the value.
    public static readonly Dictionary<string , string> cache = new();

    static async Task Main()
    {
        //Url to fetch the html content
        string url = "https://132001012-tarun.github.io/static_html_page/";

        // Creating an instance of the HTML fetcher proxy.
        IHtmlFetcher htmlFetcher = new HtmlFetcherProxy();

        // Measure the time taken to fetch HTML content.
        DateTime startTime = DateTime.Now;
        string htmlContent = await htmlFetcher.GetHtmlContentAsync( url );
        DateTime endTime = DateTime.Now;

        // Print the time taken to fetch the HTML content in milliseconds.
        Console.WriteLine( $"Time taken to fetch it from the main server: {(endTime - startTime).TotalMilliseconds} ms" );

        Console.WriteLine( $"This is the content of the HtmlPage taken from main server" );
        PrintTextFromHtml( htmlContent );

       
        DateTime starTime = DateTime.Now;
        _ = await htmlFetcher.GetHtmlContentAsync( url );
        DateTime endtime = DateTime.Now;

        
        Console.WriteLine( $"Time taken to fetch it from the Cache: {(endtime - starTime).TotalMilliseconds} ms" );
        Console.WriteLine( $"This is the content of the HtmlPage taken from Cache" );
        PrintTextFromHtml( htmlContent );


        int waitTimeMilliseconds = 5000;
        await Task.Delay( waitTimeMilliseconds );


        cache.Clear();

        // Measure the time taken to fetch HTML content again after clearing the cache.
        DateTime StarTime = DateTime.Now;
        string HtmContent = await htmlFetcher.GetHtmlContentAsync( url );
        DateTime Endtime = DateTime.Now;


        Console.WriteLine( $"Time taken to fetch it from the main server after removing the cache memory: {(Endtime - StarTime).TotalMilliseconds} ms" );

        Console.WriteLine( $"This is the content of the HtmlPage taken from main memory after clearing cache" );
        PrintTextFromHtml( HtmContent );

        Console.ReadLine();
    }

    // Method to extract and print text content from HTML content.
    static void PrintTextFromHtml( string htmlContent )
    {
      
        string textContent = Regex.Replace( htmlContent , "<[^>]*>" , "" );

       
        textContent = Regex.Replace( textContent , @"\s+" , " " ).Trim();

       
        Console.WriteLine( textContent );
    }
}
