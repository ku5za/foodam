using Foodam;
using InterfaceAdapters;
using InterfaceAdapters.FoodamDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodamDatabaseDataProvider
{
	public class FoodamDatabaseRestaurantsContactDetailsDataProvider : RestaurantContactDetailsGateway
	{
		private readonly Address address;

		public FoodamDatabaseRestaurantsContactDetailsDataProvider(string street, string postalCode, string city)
		{
			address = new Address(street, postalCode, city);

			MatchingCriteria = new RestaurantsContactDetailsMatcher( rcd => rcd.Address.PostalCode == address.PostalCode);
		}

		public RestaurantsContactDetailsMatcher MatchingCriteria
		{
			get;
			set;
		}

		public override List<RestaurantContactDetails> GetListOfRestaurantsContactDetails()
		{
			RestaurantsTableAdapter restaurantsTableAdapter = new RestaurantsTableAdapter();
			var restaurantsTable = restaurantsTableAdapter.GetData();
			List<RestaurantContactDetails> listToReturn = new List<RestaurantContactDetails>();

			foreach(var restaurantContactDetails in restaurantsTable)
			{
				var fetchedRestaurantContactDetails = 
					new RestaurantContactDetails(
						restaurantContactDetails.RestaurantsName,
						restaurantContactDetails.PhoneNumber,
						new Address(
							restaurantContactDetails.Street,
							restaurantContactDetails.PostalCode,
							restaurantContactDetails.City
						)
				);

				if (MatchingCriteria(fetchedRestaurantContactDetails))
				{
					listToReturn.Add(fetchedRestaurantContactDetails);
				}
			}

			return listToReturn;
		}
	}
}
