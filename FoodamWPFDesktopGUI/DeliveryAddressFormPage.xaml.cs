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

		private void GoFurtherIfNotNull(DeliveryAddressView deliveryAddressView)
		{
			if (!(deliveryAddressView is null))
			{
				DeliveryAddressInputValidationHint_TextBlock.Text = "";

				var matchedRestaurants = GetNextPageContent(deliveryAddressView);

				if(matchedRestaurants.Length == 0)
				{
					MessageBox.Show("Nie znaleziono restauracji dla podanego adresu");
				}
				else
				{
					this.NavigationService.Navigate(new MatchingRestaurantSelectionPage(matchedRestaurants));
				}

			}
		}

		private string[] GetNextPageContent(DeliveryAddressView deliveryAddressView)
		{
			var deliveryAddress = deliveryAddressView.DeliveryAddress;
			var dataGateway = new FoodamDatabaseRestaurantsContactDetailsDataProvider(deliveryAddress.Street, deliveryAddress.PostalCode, deliveryAddress.City);
			MatchRestaurantsToDeliveryAddressController controller = new MatchRestaurantsToDeliveryAddressController(deliveryAddress, dataGateway);
			var matchedRestaurants = controller.GetMatchedRestaurantsContactDetailsView();

			return matchedRestaurants;
		}
	}
}
