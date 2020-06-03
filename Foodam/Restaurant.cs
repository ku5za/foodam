using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class Restaurant
	{
		#region field
		private RestaurantContactDetails contactDetails;
		private Menu menu;
		private List<Discount> discounts;
		#endregion

		#region properties
		public RestaurantContactDetails ContactDetails => ContactDetails;
		public Menu Menu => menu;
		public List<Discount> Discounts => discounts;
		#endregion

		#region methods
		public Restaurant(string name, string phoneNumber, Address address, Menu menu, List<Discount> discounts)
		{
			this.contactDetails = new RestaurantContactDetails(name, phoneNumber, address);
			this.menu = menu;
			this.discounts = discounts;
		}

		public Restaurant(string name, string phoneNumber, Address address, Menu menu, params Discount[] discounts)
			: this(name, phoneNumber, address, menu, new List<Discount>(discounts))
		{ }
		#endregion
	}
}