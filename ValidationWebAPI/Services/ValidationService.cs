using System;
using System.Text.Json;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{
	public class ValidationService : IValidationService
	{
		public IValidationEngine validationEngine { get; set; }
		public IDataProvider dataProvider;

		public ValidationService(IValidationEngine engine, IDataProvider provider)
		{
			validationEngine = engine;
			dataProvider = provider;
		}

		public string ValidateAndGenerateResponse(string accountinfo)
        {
			//Set rules for the engine to match input against 
			validationEngine.AddNewRule(new NameRule());
			validationEngine.AddNewRule(new AccNumberRule());

			validationEngine.Validate(accountinfo);
			StoreValidationResults();

			return BuildResponse();
        }

		public void StoreValidationResults()
        {
			List<string> results = new List<string>();

			foreach(var res in validationEngine.ValidationResults)
            {
				var line =	res.InputData
							+ " validation took "
							+ res.ResultGenerationTime
							+ " milliseconds";

				results.Add(line);
            }

			dataProvider.StoreData(results);
        }

		public string BuildResponse()
        {

			List<string> invalidLines = new List<string>();

			foreach (var er in validationEngine.GetAllErrors())
            {
				var line = string.Join(",", er.Errors)
							+ " - not valid for "
							+ er.InputPosition
							+ " "
							+ er.InputData;

				invalidLines.Add(line);
			}
			

			return JsonSerializer.Serialize(new ValidationResponse(invalidLines));
        }
	}
}