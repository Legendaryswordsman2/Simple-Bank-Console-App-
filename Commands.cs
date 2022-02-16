using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
 	static public class Commands
	{
		static BankAccount account = new BankAccount("Temp", 0);

		static public void ChooseAction()
		{
			Console.WriteLine("\nWhat would you like to do? Options: \n\nCreate Account (Replaces current account)\n\nDeposite\n\nWithdrawal\n\nView History");

			string command = Console.ReadLine();

			if (command == "Create Account")
			{
				CreateAccount();
			}

			if (command == "Deposite")
			{
				makeDeposite();
			}

			if(command == "View History")
			{
				string history = account.GetAccountHistory();
				Console.WriteLine(history);
			}

			if (command == "Withdrawal")
			{
				MakeWithdrawal();
			}
			else
			{
				ChooseAction();
			}

		
		}
		static void makeDeposite()
		{
			Console.WriteLine("How much would you like to deposite?");

			int depositeAmount = Convert.ToInt32(Console.ReadLine());
			account.MakeDeposite(depositeAmount, DateTime.Now, "Deposite");

			Console.WriteLine($"You now have {account.Balance}& in your account.");

			ChooseAction();
		}
		static void MakeWithdrawal()
		{
			Console.WriteLine("How much would you like to withdraw?");

			int withdrawalAmount = Convert.ToInt32(Console.ReadLine());
			account.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Withdrawal");

			Console.WriteLine($"You now have {account.Balance}& in your account.");

			ChooseAction();
		}
		static void CreateAccount()
		{
			string accountName;
			int depositAmount = 0;


			Console.WriteLine("Whats the name of the account?");
			accountName = Console.ReadLine();

			Console.WriteLine("Would you like to make an inital deposit?");

			string responce = Console.ReadLine();

			if (responce == "Yes")
			{
				Console.WriteLine("How much would you like to deposite?");

				depositAmount = Convert.ToInt32(Console.ReadLine());
			} // If they don't deposite anything then the deposite stays 0

			account = new BankAccount(accountName, depositAmount);
			Console.WriteLine($"Created Account with name {account.Owner} and with an inital deposite of {depositAmount}$");

			ChooseAction();
		}
	}
}
