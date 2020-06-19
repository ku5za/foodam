using System.Text.Json;

namespace InterfaceAdapters
{
	internal class MatchRestaurantsToDeliveryAddressView
	{
		private MatchRestaurantsToDeliveryAddressModel model;

		public MatchRestaurantsToDeliveryAddressView(MatchRestaurantsToDeliveryAddressModel model)
		{
			this.model = model;
		}

		public string GetMatchedRestaurantsContactDetailsJSON()
		{
			var restaurantsContactDetailsList = model.GetMatchingRestaurantsContactDetails();
			return JsonSerializer.Serialize(restaurantsContactDetailsList);
		}
	}
}