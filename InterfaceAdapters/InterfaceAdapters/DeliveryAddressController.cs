using Foodam;
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
		private DeliveryAddressModel GetDeliveryAddressModel(Address passedDeliveryAddress)
		{
			return new DeliveryAddressModel(passedDeliveryAddress);
		}

		public DeliveryAddressView GetDeliveryAddresView(Address passedDeliveryAddress)
		{
			var model = GetDeliveryAddressModel(passedDeliveryAddress);
			DeliveryAddressView deliveryAddressView = new DeliveryAddressView(model);

			if(deliveryAddressView.IsCorrectInput)
			{
				return deliveryAddressView;
			}
			else
			{
				throw new Exception(deliveryAddressView.Hint);
			}
		}
		#endregion
	}
}