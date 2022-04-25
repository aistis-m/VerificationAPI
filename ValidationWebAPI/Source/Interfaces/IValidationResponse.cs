using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationResponse
	{
		public bool fileValid { get; set; }
		public List<string> invalidLines { get; set; }
	}
}

