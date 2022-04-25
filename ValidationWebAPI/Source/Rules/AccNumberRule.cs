using System;
using System.Text.RegularExpressions;
using ValidationWebAPI.Services.Interfaces;

namespace ValidationWebAPI.Services
{

		public class AccNumberRule : IValidationRule
		{
			public string RuleName { get; set; }

			public AccNumberRule()
			{
				RuleName = "Account Number";
			}

			public bool IsMatch(string name)
			{
				// ([A-Z]{1}) - First char is uppercase
				// ([a-zA-Z]*) - Remaining symbols contain only letters

				Regex pattern = new Regex(@"\s(3|4)([0-9]{6})(p|$)$");

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

