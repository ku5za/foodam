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
		private string name;
		private string description;
		private string quantity;
		private double price;
		#endregion
		
		#region properties
		public string Name
		{
			get => name.Length == 0 ? "Menu item name not assigned" : name;
			set => name = value;
		}

		public string Description
		{
			get => description.Length == 0 ? "Description not assigned" : description;
			set => description = value;
		}

		public string Quantity
		{
			get => quantity.Length == 0 ? "Quantitiy not assigned" : quantity;
			set => quantity = value;
		}

		public double Price
		{
			get => price;
			set => price = value >= 0 ? value : 0;
		}
		#endregion

		#region methods
		public MenuItem(string name, string description, string quantity, double price)
		{
			Name = name;
			Description = description;
			Quantity = quantity;
			Price = price;
		}
		#endregion
	}
}
