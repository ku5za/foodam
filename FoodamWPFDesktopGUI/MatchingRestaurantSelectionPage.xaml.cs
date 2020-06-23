using Foodam;
using FoodamDatabaseDataProvider;
using InterfaceAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
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

namespace FoodamWPFDesktopGUI
{
	/// <summary>
	/// Interaction logic for MatchingRestaurantSelectionPage.xaml
	/// </summary>
	public delegate void AnyRestaurantFoundHandler();
	public partial class MatchingRestaurantSelectionPage : Page
	{
		private event AnyRestaurantFoundHandler AnyRestaurantFound;
		public MatchingRestaurantSelectionPage(Address deliveryAddress)
		{
			InitializeComponent();

			RestaurantSelectionForwards_Button.IsEnabled = false;
			AnyRestaurantFound += OnAnyRestaurantFound;

			SetMatchedRestaurantListContent(deliveryAddress);
		}

		private void OnAnyRestaurantFound()
		{
			RestaurantSelectionForwards_Button.IsEnabled = true;
		}

		private void RestaurantSelectionBackwards_Button_Click(object sender, RoutedEventArgs e)
		{
			var previousPage = new DeliveryAddressFormPage();
			NavigationService.Navigate(previousPage);
		}

		private async void SetMatchedRestaurantListContent(Address deliveryAddress)
		{
			var matchedRestaurantsList = await GetMatchedRestaurantsAsync(deliveryAddress);
			var restaurantsList = JsonSerializer.Deserialize<RestaurantContactDetails[]>(matchedRestaurantsList);

			if(restaurantsList.Length > 0)
			{
				AnyRestaurantFound?.Invoke();
			}

			foreach (var listItem in restaurantsList)
			{
				RestaurantSelection_ListBox.Items.Add(
					new
					{
						Name = listItem.Name,
						PhoneNumber = listItem.PhoneNumber,
						Address = $"{listItem.Address.Street}, {listItem.Address.PostalCode} {listItem.Address.City}"
					}
				);
			}
		}

		private Task<string> GetMatchedRestaurantsAsync(Address deliveryAddress)
		{
			var dataGateway = new FoodamDatabaseRestaurantsContactDetailsDataProvider(deliveryAddress.Street, deliveryAddress.PostalCode, deliveryAddress.City);
			var controller = new MatchRestaurantsToDeliveryAddressController(deliveryAddress, dataGateway);
			var matchedRestaurantsTask = Task.Run(() => controller.GetMatchedRestaurantsContactDetailsView());

			return matchedRestaurantsTask;
		}
	}
}