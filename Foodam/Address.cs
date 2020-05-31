using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Foodam
{
	class Address
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
		}
		
		public string PostalCode
		{
			get => postalCode.Length == 0 ? "Postal code not assigned" : postalCode;
		}

		public string City
		{
			get => city.Length == 0 ? "City name not assigned" : city;
		}
		#endregion

		#region methods
		public Address(string street, string postalCode, string city)
		{
			this.street = street;
			this.postalCode = postalCode;
			this.city = city;
		}

		public string GetFullAddress()
		{
			return $"{Street}, {PostalCode} {City}";
		}
		#endregion
	}
}
