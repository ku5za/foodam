using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class DiscountPercentage : Discount
	{
		#region fields
		private double discountPercent;
		#endregion

		#region methods
		public DiscountPercentage(double discountPercent, List<string> discountComponentialMenuItemClasses)
			: base(discountComponentialMenuItemClasses)
		{
			this.discountPercent = discountPercent;
		}

		public DiscountPercentage(double discountPercent, params string[] discountComponentialMenuItemClasses)
			: base(discountComponentialMenuItemClasses)
		{
			this.discountPercent = discountPercent;
		}

		public override double CalculateDecreasedPrice(List<MenuItem> menuItems)
		{
			double totalPrice = 0d;

			foreach(var menuItem in menuItems)
			{
				totalPrice += menuItem.Price;
			}

			return totalPrice * (1.0d - discountPercent);
		}
		#endregion
	}
}
