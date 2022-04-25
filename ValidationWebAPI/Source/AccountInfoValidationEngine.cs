using System;
using System.Diagnostics;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{


	public class AccountInfoValidationEngine : IValidationEngine
	{
		public List<IValidationRule> ValidationRules { get; set; }
		public List<IValidationResult> ValidationResults { get; set; }

		public AccountInfoValidationEngine(){

			ValidationRules = new List<IValidationRule>();
			ValidationResults = new List<IValidationResult>();
			
		}

		public void Validate(string accountInfo)
        {
			var watch = new Stopwatch();

			var data = accountInfo.Split("\n");



			for (int i = 0; i < data.Length; i++)
			{
				watch.Start();
				List<string> failedValidations = new List<string>();

				foreach (var rule in ValidationRules)
				{
					if (!rule.IsMatch(data[i]))
					{
						failedValidations.Add(rule.RuleName);
					}
				}

				watch.Stop();

				var result = new AccountValidationResult(i+1,data[i],watch.Elapsed.Milliseconds,failedValidations);
				ValidationResults.Add(result);

			}

        }

		public void AddNewRule(IValidationRule rule)
        {
			ValidationRules.Add(rule);
        }

		public List<IValidationResult> GetAllErrors()
        {
			return ValidationResults.FindAll(x => x.Errors.Count != 0);
        }
	}

}


