using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class Restaurant
	{
		#region field
		private string name;
		private string phoneNumber;
		private Address address;
		private Menu menu;
		private List<Discount> discounts;
		#endregion

		#region properties
		public string Name => name;
		public string PhoneNumber => phoneNumber;
		public Address Address => address;
		public Menu Menu => menu;
		public List<Discount> Discounts => discounts;
		#endregion

		#region methods
		public Restaurant(string name, string phoneNumber, Address address, Menu menu, List<Discount> discounts)
		{
			this.name = name;
			this.phoneNumber = phoneNumber;
			this.address = address;
			this.menu = menu;
			this.discounts = discounts;
		}

		public Restaurant(string name, string phoneNumber, Address address, Menu menu, params Discount[] discounts)
			: this(name, phoneNumber, address, menu, new List<Discount>(discounts))
		{ }
		#endregion
	}
}