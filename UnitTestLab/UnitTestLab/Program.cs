using System;
using System.Collections.Generic;

namespace UnitTestLab
{
    public class BankAccount
    {
        private int sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> history;

        public int SortCode
        {
            get { return sortCode; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public double OverdraftLimit
        {
            get { return overdraftLimit; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public BankAccount(int sortCode, string accountNumber, double overdraftLimit)
        {
            if (overdraftLimit >= 0)
            {
                this.sortCode = sortCode;
                this.accountNumber = accountNumber;
                this.overdraftLimit = overdraftLimit;
                this.balance = 0;
                history = new List<double>();
            }
            else
            {
                throw new Exception("Overdraft must be more than 0");
            }
        }

        public BankAccount(int sortCode, string accountNumber)
        {
            this.sortCode = SortCode;
            this.accountNumber = accountNumber;
            this.overdraftLimit = 0;
            this.balance = 0;
            history = new List<double>();
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                balance += amount;
                history.Add(amount);
            }
            else
            {
                throw new Exception("A positive amount must be deposited");
            }
        }

        public void Withdraw(double amount)
        {
            if ((balance + overdraftLimit) < amount)
            {
                balance -= amount;
                history.Add(amount * -1);
            }
            else
            {
                throw new Exception("Not enough Money in the acc");
            }
        }

        public override string ToString()
        {
            String output =  String.Format("The Bank Account Number is: {0} \n" +
                "The Sort Code is: {1} \n" +
                "The Overdraft Limit is: {2} \n" +
                "The Balance is {3}", AccountNumber, SortCode, OverdraftLimit, Balance);
            output += "History Of Transaction: ";
            foreach (double transaction in history)
            {
                output = +transaction + "";
            }

            return output;

        }
    }
}
