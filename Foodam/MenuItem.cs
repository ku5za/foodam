using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Foodam
{
	public class MenuItem
	{
		#region fields
		protected string name;
		protected string itemClass;
		protected string description;
		protected string quantity;
		protected double price;
		#endregion
		
		#region properties
		public string Name
		{
			get => name.Length == 0 ? "Menu item name not assigned" : name;
		}

		public virtual string ItemClass
		{
			get => itemClass.Length == 0 ? "Menu item class not assigned" : itemClass;
		}

		public string Description
		{
			get => description.Length == 0 ? "Description not assigned" : description;
		}

		public string Quantity
		{
			get => quantity.Length == 0 ? "Quantitiy not assigned" : quantity;
		}

		public double Price
		{
			get => price < 0 ? 0 : price;
		}
		#endregion

		#region methods
		public MenuItem(string name, string itemClass, string description, string quantity, double price)
		{
			this.name = name;
			this.itemClass = itemClass;
			this.description = description;
			this.quantity = quantity;
			this.price = price;
		}
		#endregion
	}
}