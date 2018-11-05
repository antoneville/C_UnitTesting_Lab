using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;
using System.Collections.Generic;

namespace UnitTest.Test
{
    [TestClass]
    public class UnitTest
    {
        //Negative Values - Should have Exceptions handled
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BankAccount_OverdaftConstructor_TestNegative()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633", -100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Deposit_Transaction_TestNegativeAmount()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633", 25);
            double dep = -2.50;
            r1.Deposit(dep);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Withdraw_CheckAccount_NotSufficientFunds()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633");
            r1.Deposit(49);
            r1.Withdraw(50);
        }

        //positives
        [TestMethod]
        public void Withdraw_PositiveScenario_SufficientFunds()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633");
            r1.Deposit(500);
            r1.Withdraw(50);
            Assert.AreEqual(r1.Balance, 450);
        }

        [TestMethod]
        public void Deposit_PositiveScenario_CorrectValue()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633", 100);
            r1.Deposit(500);
            Assert.AreEqual(r1.Balance, 500);
        }

        [TestMethod]
        public void HistoryList_TransactionHistory_PositiveAndNegativeValues()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633", 100);
            r1.Deposit(20);
            r1.Deposit(500);
            r1.Withdraw(5);
            r1.Deposit(40);
            Assert.AreEqual(r1.Balance, 555);
            CollectionAssert.AreEqual(r1.History, new List<double>() { 20, 500, -5, 40 });
        }

        [TestMethod]
        public void ToString_OutputCorrect_Positive()
        {
            BankAccount r1 = new BankAccount(353145, "AIBK3345666633", 100);
            r1.Deposit(100);
            List<double> tester = new List<double>();
            tester.Add(100);

            String output = String.Format("The Bank Account Number is: {0} \n" +
                "The Sort Code is: {1} \n" +
                "The Overdraft Limit is: {2} \n" +
                "The Balance is {3}", "AIBK3345666633", 353145, 100, 100);
            output += "History Of Transaction: ";
            foreach (double transaction in tester)
            {
                output = +transaction + "";
            }

            Assert.AreEqual(r1.ToString(), output);
        }
    }
}
