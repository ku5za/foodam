using Foodam;
using System.Collections.Generic;

namespace InterfaceAdapters
{
	public interface IRestaurantToDeliveryAddressMatcher
	{
		bool IsMatchingRestaurantsContactDetails(Address address, RestaurantContactDetails restaurantContactDetails);
	}
}