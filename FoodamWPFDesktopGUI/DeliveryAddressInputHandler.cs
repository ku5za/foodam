using Foodam;
using InterfaceAdapters;
using System;
using System.Linq;
using System.Windows.Controls;

namespace FoodamWPFDesktopGUI
{
	public delegate void CorrectDeliveryAddressHandler();
	
	internal class DeliveryAddressInputHandler
	{
		public event CorrectDeliveryAddressHandler CorrectDeliveryAddressPassed;

		private readonly TextBox deliveryAddressInput;
		private readonly TextBlock inputValidationHintTextBlock;
		private const string defaultHint = "Wprowadz pełen adres w formacie: Świętokrzyska 31/33, 00-001 Warszawa";

		private InputValidators.ValidatorTemplate<string> streetValidator = InputValidators.StandardStreetValidator;
		private InputValidators.ValidatorTemplate<string> postalCodeValidator = InputValidators.StandardPostalCodeValidator;
		private InputValidators.ValidatorTemplate<string> cityValidator = InputValidators.StandardCityValidator;

		public bool IsInputValid { get; private set; }
		public string InputValidationHint { get; private set; }

		public DeliveryAddressInputHandler(TextBox deliveryAddressInput, TextBlock inputValidationHintTextBlock)
		{
			this.deliveryAddressInput = deliveryAddressInput;
			this.inputValidationHintTextBlock = inputValidationHintTextBlock;
		}

		public Address SplitDeliveryAddressIntoDetails()
		{
			string deliveryAddress = deliveryAddressInput.Text;
			IsInputValid = true;
			var potentialDeliveryAddress = new Address();

			if (deliveryAddress.Length == 0)
			{
				SetInvalidInputStatus(defaultHint);
				return null;
			}

			var streetAndCityDetailsSeparated =
				deliveryAddress
				.Trim()
				.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);

			try
			{
				string separatedStreet = streetAndCityDetailsSeparated[0].Trim();
				if (streetValidator(separatedStreet))
				{
					potentialDeliveryAddress.Street = separatedStreet;
				}
				else
				{
					SetInvalidInputStatus("Nazwa ulicy powinna składać się z co najmniej 3 znaków i posiadać numer domu. Dozwolone znaki to litery, liczby, myślniki oraz spacje.");
					return null;
				}

				var postalCodeAndCitySeparated =
					streetAndCityDetailsSeparated[1]
					.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
					.ToList();
				postalCodeAndCitySeparated.RemoveAll(x => x == "");

				string separatedPostalCode = postalCodeAndCitySeparated[0];
				if(postalCodeValidator(separatedPostalCode))
				{
					potentialDeliveryAddress.PostalCode = separatedPostalCode;
				}
				else
				{
					SetInvalidInputStatus("Kod pocztowy musi być podany w formacie ll-lll, gdzie 'l' to liczba.");
					return null;
				}

				string separatedCity = postalCodeAndCitySeparated[1];
				if(cityValidator(separatedCity))
				{
					potentialDeliveryAddress.City = separatedCity;
				}
				else
				{
					SetInvalidInputStatus("Nazwa miasta powinna zawierać tylko znaki alfabetu polskiego oraz składać się z co najmniej 2 znaków.");
					return null;
				}
			}
			catch (IndexOutOfRangeException)
			{
				SetInvalidInputStatus(defaultHint);
				return null;
			}
			catch (ArgumentOutOfRangeException)
			{
				SetInvalidInputStatus(defaultHint);
				return null;
			}

			CorrectDeliveryAddressPassed?.Invoke();
			return potentialDeliveryAddress;
		}

		private void SetInvalidInputStatus(string validationHint)
		{
			IsInputValid = false;
			inputValidationHintTextBlock.Text = validationHint;
		}
	}
}