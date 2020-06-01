using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public abstract class Discount
	{
		private List<string> menuItemClassesOnDiscount;

		public Discount(List<string> menuItemClassesOnDiscount)
		{
			this.menuItemClassesOnDiscount = menuItemClassesOnDiscount;
		}

		public abstract double CalculateDecreasedPrice(List<MenuItem> menuItems);
	}
}