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

		public DeliveryAddressView GetDeliveryAddresView(string deliveryAddressInput)
		{
			var model = GetDeliveryAddressModel(deliveryAddressInput);
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

		//public List<string> GetMatchingRestaurantsList(Add)
		#endregion
	}
}