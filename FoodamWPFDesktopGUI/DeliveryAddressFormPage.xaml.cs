using Foodam;
using FoodamDatabaseDataProvider;
using InterfaceAdapters;
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
		private event EventHandler CorrectDeliveryAddressPassed;
		private bool isInputValid = false;
		public DeliveryAddressFormPage()
		{
			InitializeComponent();
		}

		private void SearchRestaurants_Button_Click(object sender, RoutedEventArgs e)
		{
			DeliveryAddressController deliveryAddressController = new DeliveryAddressController();
			string deliveryAddressInput = DeliveryAddressInput_TextBox.Text;
			DeliveryAddressView deliveryAddressView = null;

			try
			{
				deliveryAddressView = deliveryAddressController.GetDeliveryAddresView(deliveryAddressInput);
			}
			catch(Exception exc)
			{
				DeliveryAddressInputValidationHint_TextBlock.Text = exc.Message;
			}

			GoFurtherIfNotNull(deliveryAddressView);
		}

		private Address SplitDeliveryAddressIntoDetails(string deliveryAddress)
		{
			isInputValid = true;
			string deliveryAddressInputHint = "Wprowadz pełen adres w formacie: Świętokrzyska 31/33, 00-001 Warszawa";
			var validationHintHolder = DeliveryAddressInputValidationHint_TextBlock.Text;
			var potentialDeliveryAddress = new Address();

			if (deliveryAddress.Length == 0)
			{
				isInputValid = false;
				validationHintHolder = deliveryAddressInputHint;
				return null;
			}

			var streetAndCityDetailsSeparated = deliveryAddress.Trim().Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

			try
			{
				potentialDeliveryAddress.Street = streetAndCityDetailsSeparated[0].Trim();

				var postalCodeAndCitySeparated =
					streetAndCityDetailsSeparated[1]
					.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
					.ToList();
				postalCodeAndCitySeparated.RemoveAll(x => x == "");

				potentialDeliveryAddress.PostalCode = postalCodeAndCitySeparated[0];
				potentialDeliveryAddress.City = postalCodeAndCitySeparated[1];
			}
			catch (IndexOutOfRangeException)
			{
				isInputValid = false;
				validationHintHolder = deliveryAddressInputHint;
				return null;
			}
			catch (ArgumentOutOfRangeException)
			{
				isInputValid = false;
				validationHintHolder = deliveryAddressInputHint;
				return null;
			}

			return potentialDeliveryAddress;
		}

		private async void GoFurtherIfNotNull(DeliveryAddressView deliveryAddressView)
		{
			if (deliveryAddressView != null)
			{
				DeliveryAddressInputValidationHint_TextBlock.Text = "";

				var matchedRestaurants = await GetNextPageContentAsync(deliveryAddressView);

				if(matchedRestaurants.Length == 0)
				{
					MessageBox.Show("Nie znaleziono restauracji dla podanego adresu");
				}
				else
				{
					NavigationService.Navigate(new MatchingRestaurantSelectionPage(matchedRestaurants));
				}
			}
		}

		private async Task<string> GetNextPageContentAsync(DeliveryAddressView deliveryAddressView)
		{
			var deliveryAddress = deliveryAddressView.DeliveryAddress;
			var dataGateway = new FoodamDatabaseRestaurantsContactDetailsDataProvider(deliveryAddress.Street, deliveryAddress.PostalCode, deliveryAddress.City);
			var controller = new MatchRestaurantsToDeliveryAddressController(deliveryAddress, dataGateway);
			var matchedRestaurants = await Task.Run(() => controller.GetMatchedRestaurantsContactDetailsView());

			return matchedRestaurants;
		}
	}
}
