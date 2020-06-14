using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace InterfaceAdapters
{
	internal class MatchRestaurantsToDeliveryAddressModel
	{
		private Address DeliveryAddress
		{
			get;
			set;
		}

		private RestaurantsContactDetailsGateway DataGateway
		{
			get;
			set;
		}

		internal MatchRestaurantsToDeliveryAddressModel(Address deliveryAddress, RestaurantsContactDetailsGateway dataGateway)
		{
			DeliveryAddress = deliveryAddress;
			DataGateway = dataGateway;
		}

		internal List<RestaurantContactDetails> GetMatchingRestaurantsContactDetails()
		{
			MatchRestaurantsToDeliveryAddress matchRestaurants = new MatchRestaurantsToDeliveryAddress(DeliveryAddress, DataGateway);

			return matchRestaurants.GetMatchingRestaurantsList();
		}
	}
}
