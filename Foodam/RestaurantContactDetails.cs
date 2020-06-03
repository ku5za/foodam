using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class RestaurantContactDetails
	{
		#region fields
		private readonly string name;
		private readonly string phoneNumber;
		private readonly Address address;
		#endregion

		#region properties
		public string Name => name;
		public string PhoneNumber => phoneNumber;
		public Address Address => address;
		#endregion

		#region methods
		public RestaurantContactDetails(string name, string phoneNumber, Address address)
		{
			this.name = name;
			this.phoneNumber = phoneNumber;
			this.address = address;
		}
		#endregion
	}
}
