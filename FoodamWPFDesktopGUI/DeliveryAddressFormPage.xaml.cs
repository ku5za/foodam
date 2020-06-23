using Foodam;
using FoodamDatabaseDataProvider;
using InterfaceAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
			Address deliveryAddress = inputHandler.SplitDeliveryAddressIntoDetails();
			//var nextPageContentTask = Task.Run(() => new MatchingRestaurantSelectionPage(deliveryAddress));

			try
			{
				var deliveryAddressView = deliveryAddressController.GetDeliveryAddresView(deliveryAddress);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			NavigationService.Navigate(new MatchingRestaurantSelectionPage(deliveryAddress));
		}
	}
}
