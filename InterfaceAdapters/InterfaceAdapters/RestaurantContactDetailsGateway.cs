using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace InterfaceAdapters
{
	public abstract class RestaurantContactDetailsGateway : IRestaurantsContactDetailsListProvider
	{
		public delegate bool RestaurantsContactDetailsMatcher(RestaurantContactDetails restaurantContactDetails);

		public abstract List<RestaurantContactDetails> GetListOfRestaurantsContactDetails();
	}
}
