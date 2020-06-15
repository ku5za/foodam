using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class RestaurantContactDetails
	{
		#region properties
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public Address Address { get; set; }
		#endregion

		#region methods
		public RestaurantContactDetails()
		{ }
		public RestaurantContactDetails(string name, string phoneNumber, Address address)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			Address = address;
		}
		#endregion
	}
}
