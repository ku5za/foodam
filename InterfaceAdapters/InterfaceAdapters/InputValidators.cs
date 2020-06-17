using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterfaceAdapters
{
	public static class InputValidators
	{
		public delegate bool ValidatorTemplate<T>(T input);
		public static readonly ValidatorTemplate<string> StandardStreetValidator
			= x => new Regex(@"\b[a-zA-Z\p{IsLatinExtended-A}- ]{3,}\ \d{1,3}[a-zA-Z]?/?\d{0,4}\b").IsMatch(x);
		public static readonly ValidatorTemplate<string> StandardPostalCodeValidator
			= x => new Regex(@"^\b\d\d-\d\d\d\b").IsMatch(x);
		public static readonly ValidatorTemplate<string> StandardCityValidator
			= x => new Regex(@"\b[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ]{3,}\b").IsMatch(x);
	}
}