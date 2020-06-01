using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class MenuItemVariation : MenuItem
	{
		#region fields
		private string variation;
		#endregion

		#region properties
		public string Variation
		{
			get => variation.Length == 0 ? "Variation not assigned" : variation;
		}
		#endregion

		#region methods
		public MenuItemVariation(string name, string itemClass, string variation, string description, string quantity, double price)
			: base(name, itemClass, description, quantity, price)
		{
			this.variation = variation;
		}
		#endregion
	}
}