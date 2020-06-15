using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Foodam
{
	public class Address
	{
		#region properties
		public string Street { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		#endregion

		#region methods
		public Address() 
		{ }

		public Address(string street, string postalCode, string city)
		{
			Street = street;
			PostalCode = postalCode;
			City = city;
		}
		#endregion
	}
}
