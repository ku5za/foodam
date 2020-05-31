using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Foodam
{
	class DeliveryAddress
	{
		#region fields
		private string street;
		private string postalCode;
		private string city;
		#endregion

		#region properties
		public string Street
		{
			get => street.Length == 0 ? "Street not assigned" : street;
			set => street = value;
		}

		public string PostalCode
		{
			get => postalCode.Length == 0 ? "Postal code not assigned" : postalCode;
			set => postalCode = value;
		}

		public string City
		{
			get => city.Length == 0 ? "City name not assigned" : city;
			set => city = value;
		}
		#endregion

		#region methods
		public DeliveryAddress(string street, string postalCode, string city)
		{
			Street = street;
			PostalCode = postalCode;
			City = city;
		}

		public string GetDeliveryAddress()
		{
			return $"{Street}, {PostalCode} {City}";
		}
		#endregion
	}
}
