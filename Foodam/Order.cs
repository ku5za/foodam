using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
	public class Order
	{
		#region fields
		private readonly Address deliveryAddress;
		private readonly RestaurantContactDetails restaurantContactDetails;
		private readonly List<MenuItem> orderedMenuItems;
		private readonly ContactDetails contactDetails;
		private readonly PaymentDetails paymentDetails;
		private readonly double totalPrice;
		#endregion

		#region properties
		public Address DeliveryAddress => deliveryAddress;
		public RestaurantContactDetails RestaurantContactDetails => restaurantContactDetails;
		public List<MenuItem> OrderedMenuItems => orderedMenuItems;
		public ContactDetails ContactDetails => contactDetails;
		public PaymentDetails PaymentDetails => paymentDetails;
		public double TotalPrice => totalPrice;
		#endregion

		#region methods
		public Order(
			Address deliveryAddress,
			RestaurantContactDetails restaurantContactDetails,
			List<MenuItem> orderedMenuItems,
			ContactDetails contactDetails,
			PaymentDetails paymentDetails,
			double totalPrice)
		{
			this.deliveryAddress = deliveryAddress;
			this.restaurantContactDetails = restaurantContactDetails;
			this.orderedMenuItems = orderedMenuItems;
			this.contactDetails = contactDetails;
			this.paymentDetails = paymentDetails;
			this.totalPrice = totalPrice;
		}
		#endregion
	}
}
