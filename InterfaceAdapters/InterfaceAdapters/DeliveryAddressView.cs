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

		public DeliveryAddressView(bool isCorrect, string hint)
		{
			IsCorrectInput = isCorrect;
			Hint = hint;
		}
	}
}