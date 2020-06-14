﻿using Foodam;
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

			if (!(deliveryAddressView is null))
			{
				MessageBox.Show("Wszystko ok");
			}
			//else
			//{
			//	DeliveryAddressInputValidationHint_TextBlock.Text = deliveryAddressView.Hint;
			//}
		}
	}
}
