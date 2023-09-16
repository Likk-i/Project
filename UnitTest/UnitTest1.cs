using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlFetcherApp.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Url for testing
        private const string ValidUrl = "https://132001012-tarun.github.io/static_html_page/"; 
        private const string InvalidUrl = "https://this-url-does-not-exist.com";

        // Test 1: Validate that GetHtmlContentAsync for a valid URL returns HTML content.
        [TestMethod]
        public async Task GetHtmlContent_ValidUrl_ReturnsHtmlContent()
        {
            // Arrange
            var realHtmlFetcher = new RealHtmlFetcher();

            // Act
            string htmlContent = await realHtmlFetcher.GetHtmlContentAsync( ValidUrl );

            // Assert
            Assert.IsNotNull( htmlContent );
            Assert.IsTrue( htmlContent.Length > 0 );
        }
        // Test 2: Validate that GetHtmlContentAsync for an invalid URL throws an HttpRequestException.
        [TestMethod]
        [ExpectedException( typeof( HttpRequestException ) )] 
        public async Task GetHtmlContent_InvalidUrl_ThrowsHttpRequestException()
        {
            // Arrange
            var realHtmlFetcher = new RealHtmlFetcher();

            // Act
            _ = await realHtmlFetcher.GetHtmlContentAsync( InvalidUrl );

            // Assert
            // This test should throw an HttpRequestException for an invalid URL.
        }
        // Test 3: Validate that GetHtmlContentAsync for an HTTP URL returns HTML content.
        [TestMethod]
        public async Task GetHtmlContent_HttpUrl_ReturnsHtmlContent()
        {

            // Arrange

            string httpUrl = "http://example.com"; // HTTP URL

            var realHtmlFetcher = new RealHtmlFetcher();

            // Act
            string htmlContent = await realHtmlFetcher.GetHtmlContentAsync( httpUrl );

            // Assert
            Assert.IsNotNull( htmlContent );
            Assert.IsTrue( htmlContent.Length > 0 );
        }

        // Test 4: Validate that GetHtmlContentAsync for an empty URL throws an ArgumentException.
       
        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )] 
        public async Task GetHtmlContentAsync_EmptyUrl_ThrowsArgumentException()
        {
            // Arrange
            var realHtmlFetcher = new RealHtmlFetcher();

            // Act
            _ = await realHtmlFetcher.GetHtmlContentAsync( "" );

            // Assert
            // This test should throw an ArgumentException for an empty URL.
        }

        




    }
}
