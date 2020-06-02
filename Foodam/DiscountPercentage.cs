using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class DiscountPercentage : Discount
	{
		#region methods
		public DiscountPercentage(double discountPercent, List<string> discountComponentialMenuItemClasses)
			: base(discountPercent, discountComponentialMenuItemClasses)
		{ }

		public DiscountPercentage(double discountPercent, params string[] discountComponentialMenuItemClasses)
			: base(discountPercent, discountComponentialMenuItemClasses)
		{ }

		public override double CalculateDecreasedPrice(List<MenuItem> menuItems)
		{
			double totalPrice = 0d;

			foreach(var menuItem in menuItems)
			{
				totalPrice += menuItem.Price;
			}

			if(IsMatchingDiscountComponentials(menuItems))
			{
				totalPrice = totalPrice * (1.0d - discount);
			}

			return totalPrice;
		}
		#endregion
	}
}