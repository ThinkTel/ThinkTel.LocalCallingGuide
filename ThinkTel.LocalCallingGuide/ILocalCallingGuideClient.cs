using System;
using System.Threading.Tasks;
namespace ThinkTel.LocalCallingGuide
{
	public interface ILocalCallingGuideClient
	{
		Task<string> LookupNpaNxxRatecenterAsync(int npa, int nxx);
	}
}
