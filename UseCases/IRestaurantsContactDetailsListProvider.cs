using Foodam;
using System.Collections.Generic;

namespace UseCases
{
	public interface IRestaurantsContactDetailsListProvider
	{
		List<RestaurantContactDetails> GetListOfRestaurantsContactDetails();
	}
}
