using System;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{
	public class ValidationResponse : IValidationResponse
	{
		public bool fileValid { get; set; }
		public List<string> invalidLines { get; set; }

		public ValidationResponse(List<string> invalidLines)
		{
			this.invalidLines = invalidLines;
			fileValid = invalidLines.Count == 0;
		}
	}
}

