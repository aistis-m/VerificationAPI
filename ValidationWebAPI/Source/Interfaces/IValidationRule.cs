using System;
using System.Text.RegularExpressions;

namespace ValidationWebAPI.Services.Interfaces
{
	public interface IValidationRule
	{
		public string RuleName { get; set; }

		public bool IsMatch(string input);
	}
}
