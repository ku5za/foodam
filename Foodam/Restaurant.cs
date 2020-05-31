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
		private Address address;
		private Menu menu;
		#endregion

		#region properties
		public string Name => name;
		public Address Address => address;
		public Menu Menu => menu;
		#endregion

		#region methods
		public Restaurant(string name, Address address, Menu menu)
		{
			this.name = name;
			this.address = address;
			this.menu = menu;
		}
		#endregion
	}
}