using Foodam;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;

namespace InterfaceAdapters
{
	public class DeliveryAddressView
	{
		public bool IsCorrectInput 
		{
			get;
			private set;
		}

		public string Hint
		{
			get;
			private set;
		}
		
		public Address DeliveryAddress
		{
			get;
			private set;
		}

		public DeliveryAddressView(DeliveryAddressModel model)
		{
			IsCorrectInput = model.IsCorrectInput;
			Hint = model.Hint;

			if(IsCorrectInput)
			{
				DeliveryAddress = new Address(model.GetStreet(), model.GetPostalCode(), model.GetCity());
			}
			else
			{
				DeliveryAddress = null;
			}
		}
	}
}