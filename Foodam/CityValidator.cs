using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class CityValidator : InputValidator
	{
		public CityValidator()
			//: base(@"\A\w{3,}")
			: base(@"[^\W\d.,]{3,}")
		{ }

		public CityValidator(string regex)
			: base (regex)
		{ }
	}
}
