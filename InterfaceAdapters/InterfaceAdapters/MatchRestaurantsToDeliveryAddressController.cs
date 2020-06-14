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

		private Address DeliveryAddress
		{
			get;
			set;
		}

		public MatchRestaurantsToDeliveryAddressController(Address deliveryAddress, RestaurantsContactDetailsGateway dataGateway)
		{
			DeliveryAddress = deliveryAddress;
			DataGateway = dataGateway;
		}

		private MatchRestaurantsToDeliveryAddressModel GetMatchRestaurantsContactDetailsModel()
		{
			return new MatchRestaurantsToDeliveryAddressModel(DeliveryAddress, DataGateway);
		}

		public string[] GetMatchedRestaurantsContactDetailsView()
		{
			var model = GetMatchRestaurantsContactDetailsModel();
			var view = new MatchRestaurantsToDeliveryAddressView(model);

			return view.GetMatchedRestaurantsContactDetailsView();
		}
	}
}
