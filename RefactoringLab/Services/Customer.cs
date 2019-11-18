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
            var result = "Rental Record for " + GetName() + "\n";

            foreach (var each in _rentals)
            {
                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + each.Movie.GetCharge(each.GetDaysRented()).ToString() + "\n";
            }

            // add footer lines
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";

            return result;
        }

        public string GetTotalFrequentRenterPoints()
        {
            int frequentRenterPoints = 0;

            foreach (var each in _rentals)
            {
                frequentRenterPoints += each.Movie.GetFrequentRenterPoints(each.GetDaysRented());
            }

            return frequentRenterPoints.ToString();
        }


        public string GetTotalAmount()
        {
            double result = 0;

            foreach (var each in _rentals)
            {
                result += each.Movie.GetCharge(each.GetDaysRented());
            }

            return result.ToString();
        }
    }
}