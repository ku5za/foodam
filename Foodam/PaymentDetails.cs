using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class PaymentDetails
	{
		#region fields
		private readonly string paymentMethod;
		#endregion

		#region properties
		public string PaymentMethod => paymentMethod.Length == 0 ? "Payment method not assigned" : paymentMethod;
		#endregion

		#region methods
		public PaymentDetails(string paymentMethod) => this.paymentMethod = paymentMethod;
		#endregion
	}
}
