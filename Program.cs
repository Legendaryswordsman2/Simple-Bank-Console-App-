using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
	class Program
	{
		static void Main(string[] args)
		{
			var account = new BankAccount("Zander", 10000);
			Console.WriteLine($"Account {account.number} was created for {account.Owner} with {account.Balance}$.");

			account.MakeWithdrawal(120, DateTime.Now, "Hammock");
			account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");

			Console.WriteLine(account.GetAccountHistory());








			//// Test for a negative balance
			//try
			//{
			//	account.MakeWithdrawal(750000000, DateTime.Now, "Attempt to overdraw");
			//}
			//catch (InvalidOperationException e)
			//{
			//	Console.WriteLine("Exception caught trying to overdraw");
			//	Console.WriteLine(e.ToString());
			//}


			//try
			//{
			//	var invalidAccount = new BankAccount("Invalid", -55);
			//}
			//catch (ArgumentOutOfRangeException e)
			//{
			//	Console.WriteLine("Exception caught creating account with negative balance");
			//	Console.WriteLine(e.ToString());
			//}

			Console.ReadKey();
		}
	}
}
