using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class StreetValidator : InputValidator
	{
		public StreetValidator()
			: base(@"\A[A-z]{3,}")
		{ }

		public StreetValidator(string regex) 
			: base(regex)
		{ }
	}
}
