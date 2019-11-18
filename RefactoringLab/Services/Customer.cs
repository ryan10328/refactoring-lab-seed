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
                double thisAmount = 0;

                thisAmount = AmountForRental(each);

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease) && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        // 抽取出此 Method，原因是因為 Method 內部並沒有使用到其他類別的內容 (除了 Movie 之外)，且 thisAmount 為區域變數
        public double AmountForRental(Rental rental)
        {
            // 變更變數為 result，表示在這個方法內計算的結果
            double result = 0;
            // determine amounts for rental line
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (rental.GetDaysRented() > 2)
                        result += (rental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    result += rental.GetDaysRented() * 3;
                    break;
                case Movie.Children:
                    result += 1.5;
                    if (rental.GetDaysRented() > 3)
                        result += (rental.GetDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}