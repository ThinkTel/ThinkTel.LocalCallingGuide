using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ThinkTel.LocalCallingGuide.Tests
{
	public class LocalCallingGuideClientTest
	{
		private const string BASE_URL = "http://www.localcallingguide.com/";

#region Sample Outputs
		private const string XMLPREFIX_INVALID = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE root [
<!ENTITY Aacute           ""&#x000C1;"" >
<!ENTITY aacute           ""&#x000E1;"" >
<!ENTITY Acirc            ""&#x000C2;"" >
<!ENTITY acirc            ""&#x000E2;"" >
<!ENTITY acute            ""&#x000B4;"" >
<!ENTITY AElig            ""&#x000C6;"" >
<!ENTITY aelig            ""&#x000E6;"" >
<!ENTITY Agrave           ""&#x000C0;"" >
<!ENTITY agrave           ""&#x000E0;"" >
<!ENTITY Aring            ""&#x000C5;"" >
<!ENTITY aring            ""&#x000E5;"" >
<!ENTITY Atilde           ""&#x000C3;"" >
<!ENTITY atilde           ""&#x000E3;"" >
<!ENTITY Auml             ""&#x000C4;"" >
<!ENTITY auml             ""&#x000E4;"" >
<!ENTITY brvbar           ""&#x000A6;"" >
<!ENTITY Ccedil           ""&#x000C7;"" >
<!ENTITY ccedil           ""&#x000E7;"" >
<!ENTITY cedil            ""&#x000B8;"" >
<!ENTITY cent             ""&#x000A2;"" >
<!ENTITY copy             ""&#x000A9;"" >
<!ENTITY curren           ""&#x000A4;"" >
<!ENTITY deg              ""&#x000B0;"" >
<!ENTITY divide           ""&#x000F7;"" >
<!ENTITY Eacute           ""&#x000C9;"" >
<!ENTITY eacute           ""&#x000E9;"" >
<!ENTITY Ecirc            ""&#x000CA;"" >
<!ENTITY ecirc            ""&#x000EA;"" >
<!ENTITY Egrave           ""&#x000C8;"" >
<!ENTITY egrave           ""&#x000E8;"" >
<!ENTITY ETH              ""&#x000D0;"" >
<!ENTITY eth              ""&#x000F0;"" >
<!ENTITY Euml             ""&#x000CB;"" >
<!ENTITY euml             ""&#x000EB;"" >
<!ENTITY frac12           ""&#x000BD;"" >
<!ENTITY frac14           ""&#x000BC;"" >
<!ENTITY frac34           ""&#x000BE;"" >
<!ENTITY Iacute           ""&#x000CD;"" >
<!ENTITY iacute           ""&#x000ED;"" >
<!ENTITY Icirc            ""&#x000CE;"" >
<!ENTITY icirc            ""&#x000EE;"" >
<!ENTITY iexcl            ""&#x000A1;"" >
<!ENTITY Igrave           ""&#x000CC;"" >
<!ENTITY igrave           ""&#x000EC;"" >
<!ENTITY iquest           ""&#x000BF;"" >
<!ENTITY Iuml             ""&#x000CF;"" >
<!ENTITY iuml             ""&#x000EF;"" >
<!ENTITY laquo            ""&#x000AB;"" >
<!ENTITY macr             ""&#x000AF;"" >
<!ENTITY micro            ""&#x000B5;"" >
<!ENTITY middot           ""&#x000B7;"" >
<!ENTITY nbsp             ""&#x000A0;"" >
<!ENTITY not              ""&#x000AC;"" >
<!ENTITY Ntilde           ""&#x000D1;"" >
<!ENTITY ntilde           ""&#x000F1;"" >
<!ENTITY Oacute           ""&#x000D3;"" >
<!ENTITY oacute           ""&#x000F3;"" >
<!ENTITY Ocirc            ""&#x000D4;"" >
<!ENTITY ocirc            ""&#x000F4;"" >
<!ENTITY Ograve           ""&#x000D2;"" >
<!ENTITY ograve           ""&#x000F2;"" >
<!ENTITY ordf             ""&#x000AA;"" >
<!ENTITY ordm             ""&#x000BA;"" >
<!ENTITY Oslash           ""&#x000D8;"" >
<!ENTITY oslash           ""&#x000F8;"" >
<!ENTITY Otilde           ""&#x000D5;"" >
<!ENTITY otilde           ""&#x000F5;"" >
<!ENTITY Ouml             ""&#x000D6;"" >
<!ENTITY ouml             ""&#x000F6;"" >
<!ENTITY para             ""&#x000B6;"" >
<!ENTITY plusmn           ""&#x000B1;"" >
<!ENTITY pound            ""&#x000A3;"" >
<!ENTITY raquo            ""&#x000BB;"" >
<!ENTITY reg              ""&#x000AE;"" >
<!ENTITY sect             ""&#x000A7;"" >
<!ENTITY shy              ""&#x000AD;"" >
<!ENTITY sup1             ""&#x000B9;"" >
<!ENTITY sup2             ""&#x000B2;"" >
<!ENTITY sup3             ""&#x000B3;"" >
<!ENTITY szlig            ""&#x000DF;"" >
<!ENTITY THORN            ""&#x000DE;"" >
<!ENTITY thorn            ""&#x000FE;"" >
<!ENTITY times            ""&#x000D7;"" >
<!ENTITY Uacute           ""&#x000DA;"" >
<!ENTITY uacute           ""&#x000FA;"" >
<!ENTITY Ucirc            ""&#x000DB;"" >
<!ENTITY ucirc            ""&#x000FB;"" >
<!ENTITY Ugrave           ""&#x000D9;"" >
<!ENTITY ugrave           ""&#x000F9;"" >
<!ENTITY uml              ""&#x000A8;"" >
<!ENTITY Uuml             ""&#x000DC;"" >
<!ENTITY uuml             ""&#x000FC;"" >
<!ENTITY Yacute           ""&#x000DD;"" >
<!ENTITY yacute           ""&#x000FD;"" >
<!ENTITY yen              ""&#x000A5;"" >
<!ENTITY yuml             ""&#x000FF;"" >
<!ELEMENT root         (inputdata,prefixdata*,error*)>
<!ELEMENT error         (#PCDATA)>
<!ELEMENT inputdata    (npa?,nxx?,x?,exch?,rc?,region?,switch?,lata?,ocn?,blocks?)>
<!ELEMENT prefixdata   (npa,nxx,x,exch,rc,region,switch,switchname,switchtype,lata,ocn,company-name,ilec-ocn,ilec-name,rc-v,rc-h,rc-lat,rc-lon,effdate,discdate)>
<!ELEMENT npa          (#PCDATA)>
<!ELEMENT nxx          (#PCDATA)>
<!ELEMENT x            (#PCDATA)>
<!ELEMENT exch         (#PCDATA)>
<!ELEMENT rc           (#PCDATA)>
<!ELEMENT region       (#PCDATA)>
<!ELEMENT switch       (#PCDATA)>
<!ELEMENT switchname   (#PCDATA)>
<!ELEMENT switchtype   (#PCDATA)>
<!ELEMENT lata         (#PCDATA)>
<!ELEMENT ocn          (#PCDATA)>
<!ELEMENT company-name (#PCDATA)>
<!ELEMENT company-type (#PCDATA)>
<!ELEMENT ilec-ocn     (#PCDATA)>
<!ELEMENT ilec-name    (#PCDATA)>
<!ELEMENT rc-v         (#PCDATA)>
<!ELEMENT rc-h         (#PCDATA)>
<!ELEMENT rc-lat       (#PCDATA)>
<!ELEMENT rc-lon       (#PCDATA)>
<!ELEMENT effdate      (#PCDATA)>
<!ELEMENT discdate     (#PCDATA)>
]>
<root>
<error>NXX must be between 200 and 999.</error>
</root>";

		private const string XMLPREFIX_780_809 = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE root [
<!ENTITY Aacute           ""&#x000C1;"" >
<!ENTITY aacute           ""&#x000E1;"" >
<!ENTITY Acirc            ""&#x000C2;"" >
<!ENTITY acirc            ""&#x000E2;"" >
<!ENTITY acute            ""&#x000B4;"" >
<!ENTITY AElig            ""&#x000C6;"" >
<!ENTITY aelig            ""&#x000E6;"" >
<!ENTITY Agrave           ""&#x000C0;"" >
<!ENTITY agrave           ""&#x000E0;"" >
<!ENTITY Aring            ""&#x000C5;"" >
<!ENTITY aring            ""&#x000E5;"" >
<!ENTITY Atilde           ""&#x000C3;"" >
<!ENTITY atilde           ""&#x000E3;"" >
<!ENTITY Auml             ""&#x000C4;"" >
<!ENTITY auml             ""&#x000E4;"" >
<!ENTITY brvbar           ""&#x000A6;"" >
<!ENTITY Ccedil           ""&#x000C7;"" >
<!ENTITY ccedil           ""&#x000E7;"" >
<!ENTITY cedil            ""&#x000B8;"" >
<!ENTITY cent             ""&#x000A2;"" >
<!ENTITY copy             ""&#x000A9;"" >
<!ENTITY curren           ""&#x000A4;"" >
<!ENTITY deg              ""&#x000B0;"" >
<!ENTITY divide           ""&#x000F7;"" >
<!ENTITY Eacute           ""&#x000C9;"" >
<!ENTITY eacute           ""&#x000E9;"" >
<!ENTITY Ecirc            ""&#x000CA;"" >
<!ENTITY ecirc            ""&#x000EA;"" >
<!ENTITY Egrave           ""&#x000C8;"" >
<!ENTITY egrave           ""&#x000E8;"" >
<!ENTITY ETH              ""&#x000D0;"" >
<!ENTITY eth              ""&#x000F0;"" >
<!ENTITY Euml             ""&#x000CB;"" >
<!ENTITY euml             ""&#x000EB;"" >
<!ENTITY frac12           ""&#x000BD;"" >
<!ENTITY frac14           ""&#x000BC;"" >
<!ENTITY frac34           ""&#x000BE;"" >
<!ENTITY Iacute           ""&#x000CD;"" >
<!ENTITY iacute           ""&#x000ED;"" >
<!ENTITY Icirc            ""&#x000CE;"" >
<!ENTITY icirc            ""&#x000EE;"" >
<!ENTITY iexcl            ""&#x000A1;"" >
<!ENTITY Igrave           ""&#x000CC;"" >
<!ENTITY igrave           ""&#x000EC;"" >
<!ENTITY iquest           ""&#x000BF;"" >
<!ENTITY Iuml             ""&#x000CF;"" >
<!ENTITY iuml             ""&#x000EF;"" >
<!ENTITY laquo            ""&#x000AB;"" >
<!ENTITY macr             ""&#x000AF;"" >
<!ENTITY micro            ""&#x000B5;"" >
<!ENTITY middot           ""&#x000B7;"" >
<!ENTITY nbsp             ""&#x000A0;"" >
<!ENTITY not              ""&#x000AC;"" >
<!ENTITY Ntilde           ""&#x000D1;"" >
<!ENTITY ntilde           ""&#x000F1;"" >
<!ENTITY Oacute           ""&#x000D3;"" >
<!ENTITY oacute           ""&#x000F3;"" >
<!ENTITY Ocirc            ""&#x000D4;"" >
<!ENTITY ocirc            ""&#x000F4;"" >
<!ENTITY Ograve           ""&#x000D2;"" >
<!ENTITY ograve           ""&#x000F2;"" >
<!ENTITY ordf             ""&#x000AA;"" >
<!ENTITY ordm             ""&#x000BA;"" >
<!ENTITY Oslash           ""&#x000D8;"" >
<!ENTITY oslash           ""&#x000F8;"" >
<!ENTITY Otilde           ""&#x000D5;"" >
<!ENTITY otilde           ""&#x000F5;"" >
<!ENTITY Ouml             ""&#x000D6;"" >
<!ENTITY ouml             ""&#x000F6;"" >
<!ENTITY para             ""&#x000B6;"" >
<!ENTITY plusmn           ""&#x000B1;"" >
<!ENTITY pound            ""&#x000A3;"" >
<!ENTITY raquo            ""&#x000BB;"" >
<!ENTITY reg              ""&#x000AE;"" >
<!ENTITY sect             ""&#x000A7;"" >
<!ENTITY shy              ""&#x000AD;"" >
<!ENTITY sup1             ""&#x000B9;"" >
<!ENTITY sup2             ""&#x000B2;"" >
<!ENTITY sup3             ""&#x000B3;"" >
<!ENTITY szlig            ""&#x000DF;"" >
<!ENTITY THORN            ""&#x000DE;"" >
<!ENTITY thorn            ""&#x000FE;"" >
<!ENTITY times            ""&#x000D7;"" >
<!ENTITY Uacute           ""&#x000DA;"" >
<!ENTITY uacute           ""&#x000FA;"" >
<!ENTITY Ucirc            ""&#x000DB;"" >
<!ENTITY ucirc            ""&#x000FB;"" >
<!ENTITY Ugrave           ""&#x000D9;"" >
<!ENTITY ugrave           ""&#x000F9;"" >
<!ENTITY uml              ""&#x000A8;"" >
<!ENTITY Uuml             ""&#x000DC;"" >
<!ENTITY uuml             ""&#x000FC;"" >
<!ENTITY Yacute           ""&#x000DD;"" >
<!ENTITY yacute           ""&#x000FD;"" >
<!ENTITY yen              ""&#x000A5;"" >
<!ENTITY yuml             ""&#x000FF;"" >
<!ELEMENT root         (inputdata,prefixdata*,error*)>
<!ELEMENT error         (#PCDATA)>
<!ELEMENT inputdata    (npa?,nxx?,x?,exch?,rc?,region?,switch?,lata?,ocn?,blocks?)>
<!ELEMENT prefixdata   (npa,nxx,x,exch,rc,region,switch,switchname,switchtype,lata,ocn,company-name,ilec-ocn,ilec-name,rc-v,rc-h,rc-lat,rc-lon,effdate,discdate)>
<!ELEMENT npa          (#PCDATA)>
<!ELEMENT nxx          (#PCDATA)>
<!ELEMENT x            (#PCDATA)>
<!ELEMENT exch         (#PCDATA)>
<!ELEMENT rc           (#PCDATA)>
<!ELEMENT region       (#PCDATA)>
<!ELEMENT switch       (#PCDATA)>
<!ELEMENT switchname   (#PCDATA)>
<!ELEMENT switchtype   (#PCDATA)>
<!ELEMENT lata         (#PCDATA)>
<!ELEMENT ocn          (#PCDATA)>
<!ELEMENT company-name (#PCDATA)>
<!ELEMENT company-type (#PCDATA)>
<!ELEMENT ilec-ocn     (#PCDATA)>
<!ELEMENT ilec-name    (#PCDATA)>
<!ELEMENT rc-v         (#PCDATA)>
<!ELEMENT rc-h         (#PCDATA)>
<!ELEMENT rc-lat       (#PCDATA)>
<!ELEMENT rc-lon       (#PCDATA)>
<!ELEMENT effdate      (#PCDATA)>
<!ELEMENT discdate     (#PCDATA)>
]>
<root>
<inputdata>
<npa>780</npa>
<nxx>809</nxx>
</inputdata>
<prefixdata>
<npa>780</npa>
<nxx>809</nxx>
<x>A</x>
<exch>001000</exch>
<rc>Edmonton</rc>
<region>AB</region>
<switch>EDTNABMT4MD</switch>
<switchname></switchname>
<switchtype></switchtype>
<ocn>081E</ocn>
<company-name>Distributel Communications Ltd-AB</company-name>
<company-type>C</company-type>
<ilec-ocn>8084</ilec-ocn>
<ilec-name>TELUS</ilec-name>
<lata>888</lata>
<rc-v>4887</rc-v>
<rc-h>7824</rc-h>
<rc-lat>53.542596</rc-lat>
<rc-lon>-113.492033</rc-lon>
<effdate></effdate>
<discdate></discdate>
<udate>2013-10-11 20:37:30</udate>
</prefixdata>
</root>";
#endregion

		[Fact]
		public async Task LookupNpaNxxRatecenterAsync()
		{
			var client = new TestableLocalCallingGuideClient();

			client.SetupGet(BASE_URL + "xmlprefix.php?npa=780&nxx=809", XMLPREFIX_780_809);

			var actual = await client.LookupNpaNxxRatecenterAsync(780, 809);
			Assert.Equal("Edmonton, AB", actual);
		}

		[Fact]
		public async Task LookupNpaNxxRatecenterAsyncResponseErrors()
		{
			var client = new TestableLocalCallingGuideClient();

			var badResponse = Regex.Replace(XMLPREFIX_780_809, "<rc>(.+)</rc>", "");
			client.SetupGet(BASE_URL + "xmlprefix.php?npa=780&nxx=809", badResponse);

			await ThrowsAsync<ResponseException>(async () => await client.LookupNpaNxxRatecenterAsync(780, 809));

			badResponse = Regex.Replace(XMLPREFIX_780_809, "<region>(.+)</region>", "");
			client.SetupGet(BASE_URL + "xmlprefix.php?npa=780&nxx=809", badResponse);

			await ThrowsAsync<ResponseException>(async () => await client.LookupNpaNxxRatecenterAsync(780, 809));
		}

		[Fact]
		public async Task LookupNpaNxxRatecenterAsyncInvalidArgs()
		{
			var client = new TestableLocalCallingGuideClient();

			await ThrowsAsync<ArgumentException>(async () => await client.LookupNpaNxxRatecenterAsync(100, 809));
			await ThrowsAsync<ArgumentException>(async () => await client.LookupNpaNxxRatecenterAsync(1000, 809));
			await ThrowsAsync<ArgumentException>(async () => await client.LookupNpaNxxRatecenterAsync(780, 100));
			await ThrowsAsync<ArgumentException>(async () => await client.LookupNpaNxxRatecenterAsync(780, 1000));

			client.SetupGet(BASE_URL + "xmlprefix.php?npa=780&nxx=888", XMLPREFIX_INVALID);

			await ThrowsAsync<ServerException>(async () => await client.LookupNpaNxxRatecenterAsync(780, 888));
		}
		
		private static async Task ThrowsAsync<T>(Func<Task> codeUnderTest) where T : Exception
		{
			try
			{
				await codeUnderTest();
				Assert.Throws<T>(() => { });
			}
			catch (T) { }
		}
	}
}
