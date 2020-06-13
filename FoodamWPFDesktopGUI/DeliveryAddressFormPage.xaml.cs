using Foodam;
using FoodamDatabaseDataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UseCases;

namespace FoodamWPFDesktopGUI
{
	/// <summary>
	/// Interaction logic for DeliveryAddressFormPage.xaml
	/// </summary>
	public partial class DeliveryAddressFormPage : Page
	{
		public DeliveryAddressFormPage()
		{
			InitializeComponent();
			
			string textToDisplay = string.Empty;

			Address[] addresses =
			{
				new Address("Street1", "87-300", "Brodnica"),
				new Address("Street2", "00-213", "Warszawa"),
				new Address("Street3", "00-123", "Warszawa"),
				new Address("Street4", "40-012", "Katowice"),
				new Address("Street5", "85-111", "Bydgoszcz"),
				new Address("Street6", "05-091", "Ząbki")
			};

			foreach (var address in addresses)
			{
				FoodamDatabaseRestaurantsContactDetailsDataProvider dataProvider = new FoodamDatabaseRestaurantsContactDetailsDataProvider(address.Street, address.PostalCode, address.City);
				MatchRestaurantsToDeliveryAddress matchRestaurants = new MatchRestaurantsToDeliveryAddress(address, dataProvider);
				var matchingRestaurants = matchRestaurants.GetMatchingRestaurantsList();

				textToDisplay += $"Restauracje dla adresu {address.Street}, {address.PostalCode}, {address.City}:\n";
				foreach (var matchedRestaurant in matchingRestaurants)
				{
					textToDisplay += $"{matchedRestaurant.Name}, {matchedRestaurant.PhoneNumber}, {matchedRestaurant.Address.Street}, {matchedRestaurant.Address.PostalCode}, {matchedRestaurant.Address.City}\n";
				}

				textToDisplay += "\n";
			}


			MatchingRestaurant_TextBox.Text = textToDisplay;
		}
	}
}
