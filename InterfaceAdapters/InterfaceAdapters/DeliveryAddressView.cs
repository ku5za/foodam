using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;

namespace InterfaceAdapters
{
	public class DeliveryAddressView
	{
		public string ReturnDeliveryAddressInfo(string street, string postalCode, string city)
		{
			string toReturn = $"{street}, {postalCode} {city}";

			return toReturn;
		}
	}
}