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
		private readonly DeliveryAddressInputHandler inputHandler = null;
		
		public DeliveryAddressFormPage()
		{
			InitializeComponent();

			var deliveryAddressInput = DeliveryAddressInput_TextBox;
			var inputValidationHintTextBlock = DeliveryAddressInputValidationHint_TextBlock;
			inputHandler = new DeliveryAddressInputHandler(deliveryAddressInput, inputValidationHintTextBlock);

			SearchRestaurants_Button.IsEnabled = false;
			DeliveryAddressInput_TextBox.TextChanged += DeliveryAddressInput_TextBox_TextChanged;

			inputHandler.CorrectDeliveryAddressPassed += OnCorrectDeliveryAddressPass;
			inputHandler.IncorrectDeliveryAddressPassed += OnIncorrectDeliveryAddressPass;
		}

		private void DeliveryAddressInput_TextBox_TextChanged(object sender, RoutedEventArgs e)
		{
			inputHandler.SplitDeliveryAddressIntoDetails();
			
			//if(inputHandler.IsInputValid != true)
			//{
			//	SearchRestaurants_Button.IsEnabled = false;
			//}
		}

		private void OnCorrectDeliveryAddressPass()
		{
			SearchRestaurants_Button.IsEnabled = true;
			DeliveryAddressInputValidationHint_TextBlock.Text = "";
		}

		private void OnIncorrectDeliveryAddressPass()
		{
			SearchRestaurants_Button.IsEnabled = false;
		}

		private void SearchRestaurants_Button_Click(object sender, RoutedEventArgs e)
		{
			DeliveryAddressController deliveryAddressController = new DeliveryAddressController();
			DeliveryAddressView deliveryAddressView = null;

			if (inputHandler.IsInputValid)
			{
				string deliveryAddressInput = DeliveryAddressInput_TextBox.Text;
				Address deliveryAddress = inputHandler.SplitDeliveryAddressIntoDetails();
				try
				{
					deliveryAddressView = deliveryAddressController.GetDeliveryAddresView(deliveryAddress);
				}
				catch (Exception exc)
				{
					DeliveryAddressInputValidationHint_TextBlock.Text = exc.Message;
				}
			}
			else
			{
				DeliveryAddressInputValidationHint_TextBlock.Text = inputHandler.InputValidationHint;
			}

			GoFurtherIfNotNull(deliveryAddressView);
		}

		private async void GoFurtherIfNotNull(DeliveryAddressView deliveryAddressView)
		{
			if (deliveryAddressView != null)
			{
				DeliveryAddressInputValidationHint_TextBlock.Text = "";
				var matchedRestaurants = await GetMatchedRestaurantsAsync(deliveryAddressView);

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

		private async Task<string> GetMatchedRestaurantsAsync(DeliveryAddressView deliveryAddressView)
		{
			var deliveryAddress = deliveryAddressView.DeliveryAddress;
			var dataGateway = new FoodamDatabaseRestaurantsContactDetailsDataProvider(deliveryAddress.Street, deliveryAddress.PostalCode, deliveryAddress.City);
			var controller = new MatchRestaurantsToDeliveryAddressController(deliveryAddress, dataGateway);
			var matchedRestaurants = await Task.Run(() => controller.GetMatchedRestaurantsContactDetailsView());

			return matchedRestaurants;
		}
	}
}
