using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace InterfaceAdapters
{
	public class DeliveryAddressController
	{
		#region methods
		private DeliveryAddressModel GetDeliveryAddressModel(string deliveryAddressInput)
		{
			return new DeliveryAddressModel(deliveryAddressInput);
		}

		public string GetDeliveryAddresView(string deliveryAddressInput)
		{
			var deliveryAddressModel = GetDeliveryAddressModel(deliveryAddressInput);
			DeliveryAddressView deliveryAddressView = new DeliveryAddressView();
			return deliveryAddressView.ReturnDeliveryAddressInfo(deliveryAddressModel.GetStreet(), deliveryAddressModel.GetPostalCode(), deliveryAddressModel.GetCity());
		}
		#endregion
	}
}