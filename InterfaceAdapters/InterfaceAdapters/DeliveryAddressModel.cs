using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UseCases;

namespace InterfaceAdapters
{
	public class DeliveryAddressModel : IDeliveryAddressProvider
	{
		#region fields
		private string deliveryStreet;
		private string deliveryPostalCode;
		private string deliveryCity;
		#endregion

		#region properties
		public bool IsCorrectInput
		{
			get;
			private set;
		}

		public string Hint
		{
			get;
			private set;
		}

		private string DeliveryStreet
		{
			set
			{
				if (StreetValidator(value))
				{
					deliveryStreet = value;
				}
				else
				{
					IsCorrectInput = false;
					Hint = "Nazwa ulicy powinna składać się z co najmniej 3 znaków i posiadać numer domu. Dozwolone znaki to litery, liczby oraz myślniki.";
				}
			}
		}

		private string DeliveryPostalCode
		{
			set
			{
				if (PostalCodeValidator(value))
				{
					deliveryPostalCode = value;
				}
				else
				{
					IsCorrectInput = false;
					Hint = "Kod pocztowy musi być podany w formacie ll-lll, gdzie 'l' to liczba.";
				}
			}
		}

		private string DeliveryCity
		{
			set
			{
				if (CityValidator(value))
				{
					deliveryCity = value;
				}
				else
				{
					IsCorrectInput = false;
					Hint = "Nazwa miasta powinna zawierać tylko znaki alfabetu polskiego oraz składać się z co najmniej 2 znaków.";
				}
			}
		}

		private InputValidators.ValidatorTemplate<string> StreetValidator { get; set; }

		private InputValidators.ValidatorTemplate<string> PostalCodeValidator { get; set; }

		private InputValidators.ValidatorTemplate<string> CityValidator { get; set; }
		#endregion

		public DeliveryAddressModel(string deliveryAddress)
		{
			StreetValidator = x => new Regex(@"\b[a-zA-Z\p{IsLatinExtended-A}- ]{3,}\ \d{1,3}[a-zA-Z]?/?\d{0,4}\b").IsMatch(x);
			PostalCodeValidator = x => new Regex(@"^\b\d\d-\d\d\d\b").IsMatch(x);
			CityValidator = x => new Regex(@"\b[a-zA-ZęóąśłżźćńĘÓĄŚŁŻŹĆŃ]{3,}\b").IsMatch(x);

			IsCorrectInput = true;
			Hint = string.Empty;

			TearDeliveryAddressIntoDetails(deliveryAddress);
		}

		private void TearDeliveryAddressIntoDetails(string deliveryAddress)
		{
			string deliveryAddressInputHint = "Wprowadz pełen adres w formacie: Plac Zamkowy 1, 00-000 Warszawa";
			if (deliveryAddress.Length == 0)
			{
				IsCorrectInput = false;
				Hint = deliveryAddressInputHint;
				return;
			}

			var streetAndCityDetailsSeparated = deliveryAddress.Trim().Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

			try
			{
				DeliveryStreet = streetAndCityDetailsSeparated[0].Trim();

				var postalCodeAndCitySeparated =
					streetAndCityDetailsSeparated[1]
					.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
					.ToList();
				postalCodeAndCitySeparated.RemoveAll(x => x == "");

				DeliveryPostalCode = postalCodeAndCitySeparated[0];
				DeliveryCity = postalCodeAndCitySeparated[1];
			}
			catch(IndexOutOfRangeException)
			{
				IsCorrectInput = false;
				Hint = deliveryAddressInputHint;
			}
			catch(ArgumentOutOfRangeException)
			{
				IsCorrectInput = false;
				Hint = deliveryAddressInputHint;
			}
		}

		public string GetStreet()
		{
			return deliveryStreet;
		}

		public string GetPostalCode()
		{
			return deliveryPostalCode;
		}

		public string GetCity()
		{
			return deliveryCity;
		}
	}
}
