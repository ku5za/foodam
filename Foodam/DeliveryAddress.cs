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
		InputValidator StreetValidator;
		InputValidator PostalCodeValidator;
		InputValidator CityNameValidator;
		#endregion

		#region properties
		public string Street
		{
			get => Street;
			set
			{
				if(StreetValidator.IsValid(value))
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
				if(PostalCodeValidator.IsValid(value))
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
				if (CityNameValidator.IsValid(value)) 
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
			StreetValidator = new StreetValidator();
			PostalCodeValidator = new PostalCodeValidator();
			CityNameValidator = new CityValidator();
		}

		public string GetDeliveryAddress()
		{
			return $"{Street}, {PostalCode} {City}";
		}
		#endregion
	}
}
