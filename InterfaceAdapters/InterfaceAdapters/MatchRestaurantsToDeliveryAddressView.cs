namespace InterfaceAdapters
{
	internal class MatchRestaurantsToDeliveryAddressView
	{
		private MatchRestaurantsToDeliveryAddressModel model;

		public MatchRestaurantsToDeliveryAddressView(MatchRestaurantsToDeliveryAddressModel model)
		{
			this.model = model;
		}

		public string[] GetMatchedRestaurantsContactDetailsView()
		{
			var restaurantsContactsDetailsList = model.GetMatchingRestaurantsContactDetails();
			var listLength = restaurantsContactsDetailsList.Count;
			string[] toReturn = new string[listLength];

			for(int i = 0; i < listLength; i++)
			{
				string row = string.Empty;
				row += $"{restaurantsContactsDetailsList[i].Name}";
				row += $", {restaurantsContactsDetailsList[i].PhoneNumber}";
				row += $", {restaurantsContactsDetailsList[i].Address.Street}";
				row += $", {restaurantsContactsDetailsList[i].Address.PostalCode}";
				row += $" {restaurantsContactsDetailsList[i].Address.City}";

				toReturn[i] = row;
			}

			return toReturn;
		}
	}
}