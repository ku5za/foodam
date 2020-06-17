using Foodam;
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
					Hint = "Nazwa ulicy powinna składać się z co najmniej 3 znaków i posiadać numer domu. Dozwolone znaki to litery, liczby, myślniki oraz spacje.";
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

		public DeliveryAddressModel(Address deliveryAddress)
		{
			StreetValidator = InputValidators.StandardStreetValidator;
			PostalCodeValidator = InputValidators.StandardPostalCodeValidator;
			CityValidator = InputValidators.StandardCityValidator;

			IsCorrectInput = true;
			Hint = string.Empty;

			DeliveryStreet = deliveryAddress.Street;
			DeliveryPostalCode = deliveryAddress.PostalCode;
			DeliveryCity = deliveryAddress.City;
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
