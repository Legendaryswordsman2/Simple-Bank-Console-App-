using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
	public class BankAccount
	{
		public string number { get; private set; }
		public string Owner { get; set; }
		public decimal Balance { 
			
			get 
			{
				decimal balance = 0;
				foreach (var item in allTransactions)
				{
					balance += item.Amount;
				}
				return balance;
			} 
		}

		static int accountNumberSeed = 1234567890;

		List<Transaction> allTransactions = new List<Transaction>();

		public BankAccount(string name, decimal initialBalance)
		{
		    Owner = name;

			MakeDeposite(initialBalance, DateTime.Now, "Initial Balance");

			number = accountNumberSeed.ToString();
			accountNumberSeed++;
		}

		public void MakeDeposite(decimal amount, DateTime date, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
			}
			var deposite = new Transaction(amount, date, note);
			allTransactions.Add(deposite);
		}
		public void MakeWithdrawal(decimal amount, DateTime date, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
			}
			if(Balance - amount < 0)
			{
				throw new InvalidOperationException("Not sufficient funds for this withdrawal");
			}
			var withdrawal = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);
		}

		public string GetAccountHistory()
		{
			var report = new StringBuilder();

			// HEADER
			report.AppendLine("Date\t\tAmount\tNote");
			foreach (var item in allTransactions)
			{
				// ROWS
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
			}
			return report.ToString();
		}
	}
}
