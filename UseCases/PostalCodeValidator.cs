using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class PostalCodeValidator : InputValidator
	{
		public PostalCodeValidator()
			: base(@"\A\d{2}-\d{3}")
		{ }

		public PostalCodeValidator(string regex) 
			: base(regex)
		{ }
	}
}
