namespace UseCases
{
	public interface IDeliveryAddressProvider
	{
		string GetStreet();
		string GetPostalCode();
		string GetCity();
	}
 }