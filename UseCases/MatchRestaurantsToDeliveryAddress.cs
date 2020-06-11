using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UseCases
{
	public class MatchRestaurantsToDeliveryAddress
	{
		#region fields
		private readonly Address deliveryAddress;
		private readonly IRestaurantsContactDetailsListProvider restaurantsContactDetailsListProvider;
		#endregion

		#region methods
		public MatchRestaurantsToDeliveryAddress(
			Address deliveryAddress,
			IRestaurantsContactDetailsListProvider restaurantsContactDetailsListProvider)
		{
			this.deliveryAddress = deliveryAddress;
			this.restaurantsContactDetailsListProvider = restaurantsContactDetailsListProvider;
		}

		public MatchRestaurantsToDeliveryAddress(
			string street, string postalCode, string city,
			IRestaurantsContactDetailsListProvider restaurantsContactDetailsListProvider)
		{ 
			deliveryAddress = new Address(street, postalCode, city);
			this.restaurantsContactDetailsListProvider = restaurantsContactDetailsListProvider;
		}

		public List<RestaurantContactDetails> GetMatchingRestaurantsList()
		{
			return restaurantsContactDetailsListProvider.GetListOfRestaurantsContactDetails();
		}
		#endregion
	}
}