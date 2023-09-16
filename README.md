Proxy design pattern is demonstrated in this project that provides a surrogate or placeholder for another object to control access to it. We can implement web pages caching using this proxy design pattern. Requesting data from the main server is a expensive process. So, we can make use of this proxy design pattern to fetch data at higher speed. For this implementation we used a simple static html page. 
Here's a step-by-step explanation of how the program works:
It starts by creating an instance of the HtmlFetcherProxy class.
The program measures and prints the time taken to fetch HTML content from the specified URL using the placeholder(HtmlFetcherProxy). 
If the content is not in the cache, it fetches it from the real subject (RealHtmlFetcher), caches it, and then prints it. 
The program then waits for 15 seconds and clears the cache. It measures and prints the time taken to fetch the HTML content again. 
Since the cache has been cleared, it fetches the content from the real subject again. Finally, it prints the text content of the fetched HTML.
This code demonstrates the Proxy design pattern in action, where the proxy (HtmlFetcherProxy) adds a level of control (caching in this case) to the real subject (RealHtmlFetcher) without the client code needing to be aware of the details of caching.

Interfaces and Classes:
IHtmlFetcher: Both the real subject (RealHtmlFetcher) and the proxy (HtmlFetcherProxy) implement this interface. It defines a method GetHtmlContentAsync to fetch HTML content from a given URL. 
RealHtmlFetcher: This class represents the real subject. It uses an HttpClient to fetch HTML content from a given URL
HtmlFetcherProxy: This class represents the proxy. It wraps an instance of RealHtmlFetcher. First it checks whether the data is present in the cache memory or not if it present it fetch it from cache or it fetch it from main server and store data in the cache.
Program Class:
Main method:This is the entry point of the program.
Specifies the target URL to fetch HTML content from.
Creates an instance of HtmlFetcherProxy as the proxy for fetching HTML content.
Measures and prints the time taken to fetch HTML content the first time and then again after clearing the cache. This demonstrates the effectiveness of the caching mechanism.
Uses regular expressions to remove HTML tags and prints the text content of the fetched HTML.



