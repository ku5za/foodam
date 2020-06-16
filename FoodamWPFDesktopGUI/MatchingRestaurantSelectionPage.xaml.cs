using Foodam;
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
	public partial class MatchingRestaurantSelectionPage : Page
	{
		private delegate void addingListItemDelegate(RestaurantContactDetails item);

		public MatchingRestaurantSelectionPage(string restaurantsListContent)
		{
			InitializeComponent();

			var restaurantsList = JsonSerializer.Deserialize<RestaurantContactDetails[]>(restaurantsListContent);

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

	}
}
