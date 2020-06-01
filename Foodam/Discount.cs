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

		public abstract double CalculateDecreasedPrice(List<MenuItem> menuItems);
		#endregion
	}
}