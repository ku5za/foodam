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
			get => Street;
			set
			{
				if(streetValidator.IsValid(value))
				{
					Street = value;
				}
				else
				{
					throw new Exception("Wprowadzono niepoprawną nazwę ulicy");
				}
			}
		}

		public string PostalCode
		{
			get => PostalCode;
			set
			{
				if(postalCodeValidator.IsValid(value))
				{
					PostalCode = value;
				}
				else
				{
					throw new Exception("Wprowadzono nieprawidłowy kod pocztowy");
				}
			}
		}

		public string City
		{
			get => City;
			set
			{
				if (cityNameValidator.IsValid(value)) 
				{
					City = value;
				}
				else
				{
					throw new Exception("Wprowadzono niepoprawną nazwę miasta");
				}
			}
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
