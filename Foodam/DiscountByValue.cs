using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class DiscountByValue : Discount
	{

		public DiscountByValue(double discountValue, List<string> discountComponentialMenuItemClasses)
			: base(discountValue, discountComponentialMenuItemClasses)
		{ }
		
		public DiscountByValue(double discountValue, params string[] discountComponentialMenuItemClasses)
			: base(discountValue, discountComponentialMenuItemClasses)
		{ }

		public override double CalculateDecreasedPrice(List<MenuItem> menuItems)
		{
			double totalPrice = 0d;

			foreach (var menuItem in menuItems)
			{
				totalPrice += menuItem.Price;
			}

			return totalPrice - discount;
		}
	}
}
