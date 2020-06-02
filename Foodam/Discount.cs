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

			for(int i = 0; i < toMatch.Count; i++)
			{
				for (int j = 0; j < menuItems.Count; j++)
				{
					if (toMatch[i] == menuItems[j].ItemClass)
					{
						toMatch.RemoveAt(i);
						menuItems.RemoveAt(j);
						i--;
						break;
					}
					else if (j == menuItems.Count - 1)
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