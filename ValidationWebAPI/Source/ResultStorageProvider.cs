using System;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{
	public class ResultStorageProvider : IDataProvider
	{
		public ResultStorageProvider()
		{
		}

		public void StoreData(List<string> data)
        {
			var filename = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + ".txt";
			File.WriteAllLines(filename, data);
		}
	}
}

