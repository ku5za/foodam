using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Foodam
{
	class DeliveryAddress
	{
		#region fields
		InputValidator streetValidator;
		InputValidator postalCodeValidator;
		InputValidator cityNameValidator;
		#endregion

		#region properties
		public string Street
		{
			get => Street.Length == 0 ? "Street not assigned" : Street;
			set => Street = value;
		}

		public string PostalCode
		{
			get => PostalCode.Length == 0 ? "Postal code not assigned" : PostalCode;
			set => PostalCode = value;
		}

		public string City
		{
			get => City.Length == 0 ? "City name not assigned" : City;
			set => City = value;
		}
		#endregion

		#region methods
		public DeliveryAddress()
		{
			streetValidator = new StreetValidator();
			postalCodeValidator = new PostalCodeValidator();
			cityNameValidator = new CityValidator();
		}

		public string GetDeliveryAddress()
		{
			return $"{Street}, {PostalCode} {City}";
		}
		#endregion
	}
}
