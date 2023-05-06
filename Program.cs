using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview_Prepare
{
    public class CardHolder
    {
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }

        public CardHolder(
            string cardNumber,
            int pin,
            string firstName,
            string lastName,
            double balance
        )
        {
            CardNumber = cardNumber;
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public static void Main(string[] args)
        {
            void PrintOptions()
            {
                Console.WriteLine("Please choose from one of the following options:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
            }

            void Deposit(CardHolder currentUser)
            {
                Console.WriteLine("How much would you like to deposit?");
                if (double.TryParse(Console.ReadLine(), out double depositAmount))
                {
                    currentUser.Balance += depositAmount;
                    Console.WriteLine($"Your new balance is: {currentUser.Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            void Withdraw(CardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw?");
                if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                {
                    if (currentUser.Balance < withdrawAmount)
                    {
                        Console.WriteLine("You do not have enough funds to withdraw that amount.");
                    }
                    else
                    {
                        currentUser.Balance -= withdrawAmount;
                        Console.WriteLine($"Your new balance is: {currentUser.Balance}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            void CheckBalance(CardHolder currentUser)
            {
                Console.WriteLine($"Current balance: {currentUser.Balance}");
            }

            List<CardHolder> cardHolders = new List<CardHolder>
            {
                new CardHolder("14212212444121", 1111, "Fred", "Stone", 200.2),
                new CardHolder("14212212444221", 3321, "Lisa", "Bell", 354.33)
            };

            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please insert your debit card: ");
            string debitCardNum;
            CardHolder currentUser = null;

            while (currentUser == null)
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.CardNumber == debitCardNum);

                if (currentUser == null)
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            while (!int.TryParse(Console.ReadLine(), out int userPin) || currentUser.Pin != userPin)
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }

            Console.WriteLine($"Welcome {currentUser.FirstName} :)");
            int option;
            do
            {
                PrintOptions();
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Deposit(currentUser);
                        break;
                    case 2:
                        Withdraw(currentUser);
                        break;
                    case 3:
                        CheckBalance(currentUser);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (option != 4);
            Console.WriteLine("Thank you! Have a nice day :)");
        }
    }
}
