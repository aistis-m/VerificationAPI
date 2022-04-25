using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationResult
	{
		public int InputPosition { get; set; }
		public string InputData { get; set; }
		public double ResultGenerationTime { get; set; }
		public List<string> Errors { get; set; }
		public bool Success { get; set; }

	}
}

