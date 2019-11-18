using System;
using System.Text;
using System.Xml.XPath;

namespace RefactoringLab.Services
{
    public class Movie
    {
        private readonly string _title;

        public Movie(string title, int priceCode)
        {
            _title = title;
            SetPriceCode(priceCode);
        }

        public PriceBase Price { set; get; }

        public int GetPriceCode()
        {
            return Price.GetPriceCode();
        }

        public void SetPriceCode(int priceCode)
        {
            var code = (PriceCode) priceCode;

            switch (code)
            {
                case PriceCode.Regular:
                    Price = new RegularPrice();
                    break;
                case PriceCode.NewRelease:
                    Price = new NewReleasePrice();
                    break;
                case PriceCode.Children:
                    Price = new ChildrenPrice();
                    break;
                default:
                    throw new InvalidOperationException("Incorrect price code");
            }
        }
        public string GetTitle()
        {
            return _title;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 0;
            // add frequent renter points
            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((GetPriceCode() == (int)PriceCode.NewRelease) && daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}
