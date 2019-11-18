using System.Collections.Generic;

namespace RefactoringLab.Services
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + GetName() + "\n";

            foreach (var each in _rentals)
            {
                // 消除這個多餘的變數，可以直接用 each.GetCharge() 來代替即可

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease) && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + each.GetCharge().ToString() + "\n";
                totalAmount += each.GetCharge();
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }
}