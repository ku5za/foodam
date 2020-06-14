using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapters
{
	public class MatchRestaurantsToDeliveryAddressController
	{
		private RestaurantsContactDetailsGateway DataGateway
		{
			get;
			set;
		}

		public MatchRestaurantsToDeliveryAddressController(RestaurantsContactDetailsGateway dataGateway)
		{
			DataGateway = dataGateway;
		}

		private MatchRestaurantsToDeliveryAddressModel GetMatchRestaurantsContactDetailsModel(Address deliveryAddress)
		{
			return new MatchRestaurantsToDeliveryAddressModel(deliveryAddress, DataGateway);
		}

		public string[] GetMatchedRestaurantsContactDetailsView(Address deliveryAddress)
		{
			var model = GetMatchRestaurantsContactDetailsModel(deliveryAddress);
			var view = new MatchRestaurantsToDeliveryAddressView(model);

			return view.GetMatchedRestaurantsContactDetailsView();
		}
	}
}
