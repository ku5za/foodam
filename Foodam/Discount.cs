using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public abstract class Discount
	{
		#region fields
		protected List<string> discountComponentialMenuItemClasses;
		protected double discount;
		#endregion

		#region properties
		public List<string> DiscountComponentials => discountComponentialMenuItemClasses;
		#endregion

		#region methods
		protected Discount(double discount, List<string> discountComponentialMenuItemClasses)
		{
			this.discount = discount;
			this.discountComponentialMenuItemClasses = discountComponentialMenuItemClasses;
		}

		protected Discount(double discount, params string[] discountComponentialMenuItemClasses)
		{
			this.discount = discount;
			this.discountComponentialMenuItemClasses = new List<string>(discountComponentialMenuItemClasses);
		}

		protected bool IsMatchingDiscountComponentials(List<MenuItem> menuItems)
		{
			List<string> toMatch = new List<string>(discountComponentialMenuItemClasses);
			List<MenuItem> menuItemsCopy = new List<MenuItem>(menuItems);

			for(int i = 0; i < toMatch.Count; i++)
			{
				for (int j = 0; j < menuItemsCopy.Count; j++)
				{
					if (toMatch[i] == menuItemsCopy[j].ItemClass)
					{
						toMatch.RemoveAt(i);
						menuItemsCopy.RemoveAt(j);
						i--;
						break;
					}
					else if (j == menuItemsCopy.Count - 1)
					{
						return false;
					}
				}
			}

			return toMatch.Count == 0;
		}

		public abstract double CalculateDecreasedPrice(List<MenuItem> menuItems);
		#endregion
	}
}