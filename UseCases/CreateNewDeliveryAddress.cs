using Foodam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
	public class CreateNewDeliveryAddress
	{
		private readonly IDeliveryAddressProvider provider;
		public CreateNewDeliveryAddress(IDeliveryAddressProvider deliveryAddressProvider)
			=> provider = deliveryAddressProvider;

		public Address GetNewDeliveryAddress()
		{
			string street = provider.GetStreet();
			string postalCode = provider.GetPostalCode();
			string city = provider.GetCity();

			return new Address(street, postalCode, city);
		}
	}
}
