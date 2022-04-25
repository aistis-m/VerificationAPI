using System;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{
	public class AccountValidationResult : IValidationResult

	{
		public int InputPosition { get; set; }
		public string InputData { get; set; }
		public double ResultGenerationTime { get; set; }
		public bool Success { get; set; }
		public List<string> Errors { get; set; }

		public AccountValidationResult(int pos, string data,double time, List<string> errors)
		{
			InputPosition = pos;
			InputData = data;
			ResultGenerationTime = time;
			Errors = errors;
			Success = Errors.Count == 0;
		}
	}
}

