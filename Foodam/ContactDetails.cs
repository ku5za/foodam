using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodam
{
	public class ContactDetails
	{
		#region fields
		private string email;
		private string phoneNumber;
		#endregion

		#region properties
		public string Email => email.Length == 0 ? "Email not assigned" : email;
		public string PhoneNumber => phoneNumber.Length == 0 ? "Phone number not assigned" : phoneNumber;
		#endregion

		#region methods
		public ContactDetails(string email, string phoneNumber)
		{
			this.email = email;
			this.phoneNumber = phoneNumber;
		}
		#endregion
	}
}
