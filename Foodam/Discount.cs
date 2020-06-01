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
		#endregion

		#region properties
		public List<string> DiscountComponentials => discountComponentialMenuItemClasses;
		#endregion

		#region methods
		protected Discount(List<string> discountComponentialMenuItemClasses)
		{
			this.discountComponentialMenuItemClasses = discountComponentialMenuItemClasses;
		}

		protected Discount(params string[] discountComponentialMenuItemClasses)
		{
			this.discountComponentialMenuItemClasses = new List<string>(discountComponentialMenuItemClasses);
		}

		public abstract double CalculateDecreasedPrice(List<MenuItem> menuItems);
		#endregion
	}
}