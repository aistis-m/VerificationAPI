using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationError
	{
		public List<string> errors { get; set; }
		public string message { get; set; }
	}
}

