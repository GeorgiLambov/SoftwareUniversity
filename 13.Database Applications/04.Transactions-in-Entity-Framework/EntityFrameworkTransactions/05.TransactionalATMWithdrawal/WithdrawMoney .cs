﻿namespace ATMMachine
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;
    using ATMMachine.Data;
    using System.Data.Entity.Core;
    public class MoneyRetrievalFromATMUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Retrieving some amount of money from an ATM machine***");
            Console.Write(decorationLine);

            decimal amount = 100.32m;
            string cardNumber = "2222222222";
            string cardPin = "2222";

            try
            {
                RetrieveMoney(amount, cardNumber, cardPin);
                Console.WriteLine(
                    "You have successfully retrieved {0:C} from your account!",
                    amount);
            }
            catch (EntityException ee)
            {
                Console.WriteLine("Retrieval failed...");
                Console.WriteLine(ee.InnerException.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (TransactionException tae)
            {
                Console.WriteLine(tae.Message);
            }
        }

        static void RetrieveMoney(decimal amount, string cardNumber, string cardPin)
        {
            if (cardNumber == null)
            {
                throw new ArgumentNullException("cardNumber", "Provided card number cannot be null!");
            }

            if (cardPin == null)
            {
                throw new ArgumentNullException("cardPIN", "Provided card PIN cannot be null!");
            }

            if (cardNumber.Length != 10)
            {
                throw new ArgumentException(
                    "Provided card number is invalid! Card number must consist of 10 digits!");
            }

            if (cardPin.Length != 4)
            {
                throw new ArgumentException(
                    "Provided card PIN is invalid! Card PIN must consist of 4 digits!");
            }

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                using (var atmContext = new ATMMachineModel())
                {
                    var cardAccount = atmContext.CardAccounts.FirstOrDefault(
                        ca => ca.CardNumber.CompareTo(cardNumber) == 0 &&
                        ca.CardPIN.CompareTo(cardPin) == 0);

                    if (cardAccount == null)
                    {
                        scope.Dispose();
                        throw new TransactionException(
                            "There is no card account with provided card number and PIN!");
                    }

                    if (cardAccount.CardCash < amount)
                    {
                        scope.Dispose();
                        throw new TransactionException(
                            "There is no enough money in the account to retrive the requested amount!");
                    }

                    cardAccount.CardCash -= amount;
                    atmContext.SaveChanges();
                }

                scope.Complete();
            }
        }
    }
}