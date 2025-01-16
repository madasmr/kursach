using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Store.Web.Contractors
{
	public interface IWebContractorService
	{
		string Name { get; }
		Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri);
	}
}