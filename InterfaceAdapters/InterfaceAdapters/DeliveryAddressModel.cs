using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
					throw new Exception("Niepoprawny adres ulicy. Dozwolone znaki to litery, liczby oraz myślniki. Nazwa ulicy powinna składać się z co najmniej 5 znaków.");
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
					throw new Exception("Niepoprawny kod pocztowy. Kod pocztowy musi być podany w formacie ll-lll, gdzie 'l' to liczba.");
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
					throw new Exception("Niepoprawna nazwa miasta. Nazwa miasta powinna zawierać tylko znaki alfabetu polskiego oraz zawierać co najmniej 2 znaki.");
				}
			}
		}

		private InputValidators.ValidatorTemplate<string> StreetValidator { get; set; }

		private InputValidators.ValidatorTemplate<string> PostalCodeValidator { get; set; }

		private InputValidators.ValidatorTemplate<string> CityValidator { get; set; }
		#endregion

		public DeliveryAddressModel(string deliveryAddress)
		{
			StreetValidator = x => x.Length > 0;
			PostalCodeValidator = x => x.Length > 0;
			CityValidator = x => x.Length > 0;

			TearDeliveryAddressIntoDetails(deliveryAddress);
		}

		private void TearDeliveryAddressIntoDetails(string deliveryAddress)
		{
			var streetAndCityDetailsSeparated = deliveryAddress.Trim().Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

			DeliveryStreet = streetAndCityDetailsSeparated[0].Trim();

			var postalCodeAndCitySeparated =
				streetAndCityDetailsSeparated[1]
				.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
			postalCodeAndCitySeparated.RemoveAll(x => x == "");

			DeliveryPostalCode = postalCodeAndCitySeparated[0];
			DeliveryCity = postalCodeAndCitySeparated[1];
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
