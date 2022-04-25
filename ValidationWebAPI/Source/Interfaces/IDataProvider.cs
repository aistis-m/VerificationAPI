using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IDataProvider
	{
		public void StoreData(List<string> data);
	}
}

