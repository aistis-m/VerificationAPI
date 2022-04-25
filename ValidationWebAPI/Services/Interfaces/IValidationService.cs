using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationService
	{
		public IValidationEngine validationEngine { get; set; }

		public string ValidateAndGenerateResponse(string accountinfo);

		public void StoreValidationResults();

		public string BuildResponse();
	}
}

