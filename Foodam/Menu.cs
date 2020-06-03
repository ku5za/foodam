using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class Menu
	{
		#region fields
		private readonly List<MenuItem> menuItems = new List<MenuItem>();
		#endregion

		#region methods
		public Menu(List<MenuItem> menuItems)
		{
			this.menuItems = menuItems;
		}

		public Menu()
			: this(new List<MenuItem>())
		{ }

		public void addMenuItem(MenuItem menuItem)
		{
			menuItems.Add(menuItem);
		}

		public MenuItem GetMenuItem(int index)
		{
			if (index >= 0 && menuItems.Count > index)
			{
				return menuItems[index];
			}
			else
			{
				throw new Exception("There's no Menu Item with such index");
			}
		}

		public int GetMenuLength()
		{
			return menuItems.Count;
		}
		#endregion
	}
}
