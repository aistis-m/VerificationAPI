using System;
using System.Text.RegularExpressions;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{
	public class NameRule : IValidationRule
    {
		public string RuleName { get; set; }

		public NameRule() {
			RuleName = "Account Name";
		}

		public bool IsMatch(string name)
		{
			// ([A-Z]{1}) - First char is uppercase
			// ([a-zA-Z]*) - Remaining symbols contain only letters

			Regex pattern = new Regex(@"^([A-Z]{1})([a-zA-Z]*)\s");

			if (pattern.Match(name).Success)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}

