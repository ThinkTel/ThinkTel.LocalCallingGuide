using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ThinkTel.LocalCallingGuide.Tests
{
	public class TestableLocalCallingGuideClient : LocalCallingGuideClient
	{
		public class TestingMessageHander : HttpMessageHandler
		{
			public int Called { get; private set; }

			private HttpMethod _expectedMethod;
			private string _expectedUrl;
			private HttpContent _expectedContent;
			private HttpContent _responesContent;
			public TestingMessageHander(HttpMethod expectedMethod, string expectedUrl, HttpContent expectedContent, HttpContent responseContent)
			{
				_expectedMethod = expectedMethod;
				_expectedUrl = expectedUrl;
				_expectedContent = expectedContent;
				_responesContent = responseContent;
			}

			protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
			{
				Assert.Equal(_expectedMethod, request.Method);
				Assert.Equal(_expectedUrl, request.RequestUri.ToString());

				if (_expectedContent != null)
				{
					Assert.Equal(_expectedContent.Headers.ContentType.MediaType, request.Content.Headers.ContentType.MediaType);

					var expectedBody = await _expectedContent.ReadAsByteArrayAsync();
					var requestBody = await request.Content.ReadAsByteArrayAsync();
					Assert.Equal(expectedBody, requestBody);
				}

				Called++;

				return new HttpResponseMessage(HttpStatusCode.OK) { Content = _responesContent };
			}
		}

		private TestingMessageHander _testingMessageHandler;
		public TestingMessageHander TestingMessageHandler
		{
			get 
			{
				return _testingMessageHandler;
			}
			set 
			{
				_testingMessageHandler = value;
				client = new HttpClient(value);
			}
		}

		public void SetupGet(string url, string resp, string mediaType = "text/xml")
		{
			var content = new StringContent(resp, Encoding.UTF8, mediaType);
			TestingMessageHandler = new TestingMessageHander(HttpMethod.Get, url, null, content);
		}
	}
}
