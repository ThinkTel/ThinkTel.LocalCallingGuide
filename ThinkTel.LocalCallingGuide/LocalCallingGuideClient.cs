using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThinkTel.LocalCallingGuide
{
	public class LocalCallingGuideClient : ILocalCallingGuideClient
	{
		private const string BASE_URL = "http://www.localcallingguide.com/";

		// SEE http://en.wikipedia.org/wiki/Toll-free_telephone_number#North_America and http://nanpa.com/pdf/PL_455.pdf
		private static readonly int[] TOLL_FREE_NPAS = new int[] { 800, 888, 877, 866, 855, 844, 833, 822 };
		private const string TOLL_FREE_LABEL = "Toll-free";

		protected HttpClient client;
		public LocalCallingGuideClient() 
		{
			client = new HttpClient();
		}

		private static Dictionary<int, string> _npaNxxCache = new Dictionary<int, string>();
		public async Task<string> LookupNpaNxxRatecenterAsync(int npa, int nxx)
		{
			if (npa < 199 || npa > 999)
				throw new ArgumentException("npa");
			if (nxx < 199 || nxx > 999)
				throw new ArgumentException("nxx");

			if (TOLL_FREE_NPAS.Contains(npa))
				return TOLL_FREE_LABEL;

			var npanxx = npa * 1000 + nxx;
			if (!_npaNxxCache.ContainsKey(npanxx))
			{
				const string URL_TEMPLATE = BASE_URL + "xmlprefix.php?npa={0}&nxx={1}";
				var url = string.Format(URL_TEMPLATE, npa, nxx);
				var resp = await client.GetAsync(url);
				var xml = await resp.Content.ReadAsStringAsync();

				string rc = null, region = null;
				Match m;

				m = Regex.Match(xml, "<error>(.+)</error>");
				if (m.Success)
					throw new ServerException(m.Groups[1].Value);

				m = Regex.Match(xml, "<rc>(.+)</rc>");
				if (m.Success)
					rc = m.Groups[1].Value;
				if (string.IsNullOrEmpty(rc))
					throw new ResponseException("Missing ratecenter in response for " + npa + " " + nxx);

				m = Regex.Match(xml, "<region>(.+)</region>");
				if (m.Success)
					region = m.Groups[1].Value;
				if (string.IsNullOrEmpty(region))
					throw new ResponseException("Missing region in response for " + npa + " " + nxx);

				_npaNxxCache[npanxx] = string.Format("{0}, {1}", rc, region).Replace('é', 'e');
			}
			return _npaNxxCache[npanxx];
		}
	}
}
