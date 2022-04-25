using System;
namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationEngine
	{
		public List<IValidationResult> ValidationResults { get; set; }
		public List<IValidationRule> ValidationRules { get; set; }


		public void Validate(string data);
		public void AddNewRule(IValidationRule rule);
		public List<IValidationResult> GetAllErrors();
	}
}

