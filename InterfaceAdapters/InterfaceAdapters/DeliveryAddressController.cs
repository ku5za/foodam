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
			DeliveryAddressView deliveryAddressView = new DeliveryAddressView(true, string.Empty);
			string emptyDeliveryAddressInputHint = "Wprowadz pełen adres w formacie: Plac Zamkowy 1, 00-000 Warszawa";

			try
			{
				if (deliveryAddressInput.Length == 0)
				{
					throw new Exception(emptyDeliveryAddressInputHint);
				}
				var deliveryAddressModel = GetDeliveryAddressModel(deliveryAddressInput);
			}
			catch(Exception e)
			{
				if(e is IndexOutOfRangeException)
				{
					e = new Exception(emptyDeliveryAddressInputHint);
				}
				deliveryAddressView = new DeliveryAddressView(false, e.Message);
			}
			
			return deliveryAddressView;
		}

		//public List<string> GetMatchingRestaurantsList(Add)
		#endregion
	}
}