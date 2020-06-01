using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public abstract class Discount
	{
		protected List<string> discountComponentialMenuItemClasses;

		protected Discount(List<string> discountComponentialMenuItemClasses)
		{
			this.discountComponentialMenuItemClasses = discountComponentialMenuItemClasses;
		}

		public abstract double CalculateDecreasedPrice(List<MenuItem> menuItems);
	}
}