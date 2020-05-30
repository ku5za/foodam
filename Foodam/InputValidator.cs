using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Foodam
{
	public class InputValidator
	{
		protected Regex _regex;

		public InputValidator(string regex)
		{
			_regex = new Regex(regex);
		}

		internal bool IsValid(string input)
		{
			return _regex.IsMatch(input);
		}
	}
}