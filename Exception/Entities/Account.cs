using System;
using System.Globalization;
using Exception.Entities.Exceptions;

namespace Exception.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithrawLimit = withrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance = +amount;
        }

        public void Withdraw(double amount)
        {
            if(WithrawLimit < amount)
            
                throw new DomainException("The amount exceeds withdraw limit");

            if (WithrawLimit < amount || Balance < amount)
                throw new DomainException("Not enough balance");
            
            Balance -= amount;
        }

        public override string ToString()
        {
            return "New balance: " + Balance.ToString("F2",CultureInfo.InvariantCulture);
        }
    }
}
